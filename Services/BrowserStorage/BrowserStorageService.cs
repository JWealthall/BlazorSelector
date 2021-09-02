using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorSelector.Services
{
    public interface IBrowserStorageService
    {
        /// <summary>
        /// Clears all data from session storage.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> representing the completion of the operation.</returns>
        ValueTask ClearAsync();

        /// <summary>
        /// Retrieve the specified MessagePack data from session storage and deseralise it to the specfied type.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value specifying the name of the session storage slot to use</param>
        /// <returns>A <see cref="ValueTask"/> representing the completion of the operation.</returns>
        ValueTask<T> GetItemAsync<T>(string key);

        /// <summary>
        /// Retrieve the specified data from session storage as a <see cref="string"/>.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
        /// <returns>A <see cref="ValueTask"/> representing the completion of the operation.</returns>
        ValueTask<string> GetItemAsStringAsync(string key);

        /// <summary>
        /// Return the name of the key at the specified <paramref name="index"/>.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>A <see cref="ValueTask"/> representing the completion of the operation.</returns>
        ValueTask<string> KeyAsync(int index);

        /// <summary>
        /// Checks if the <paramref name="key"/> exists in session storage, but does not check its value.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
        /// <returns>A <see cref="ValueTask"/> representing the completion of the operation.</returns>
        ValueTask<bool> ContainKeyAsync(string key);

        /// <summary>
        /// The number of items stored in session storage.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> representing the completion of the operation.</returns>
        ValueTask<int> LengthAsync();

        /// <summary>
        /// Remove the data with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
        /// <returns>A <see cref="ValueTask"/> representing the completion of the operation.</returns>
        ValueTask RemoveItemAsync(string key);

        /// <summary>
        /// Sets or updates (in Message Pack Format) the <paramref name="data"/> in session storage with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
        /// <param name="data">The data to be saved</param>
        /// <returns>A <see cref="ValueTask"/> representing the completion of the operation.</returns>
        ValueTask SetItemAsync<T>(string key, T data);

        /// <summary>
        /// Sets or updates the <paramref name="data"/> in session storage with the specified <paramref name="key"/>. Does not serialize the value before storing.
        /// </summary>
        /// <param name="key">A <see cref="string"/> value specifying the name of the storage slot to use</param>
        /// <param name="data">The string to be saved</param>
        /// <returns></returns>
        ValueTask SetItemAsStringAsync(string key, string data);

        //event EventHandler<ChangingEventArgs> Changing;
        //event EventHandler<ChangedEventArgs> Changed;
    }

    public interface ISessionStorageService : IBrowserStorageService { }

    public interface ILocalStorageService : IBrowserStorageService { }

    public abstract class BrowserStorageService : IBrowserStorageService
    {
        private readonly IBrowserStorageProvider _storageProvider;

        protected BrowserStorageService(IBrowserStorageProvider storageProvider)
        {
            _storageProvider = storageProvider;
        }

        public ValueTask ClearAsync() => _storageProvider.ClearAsync();

        public ValueTask<bool> ContainKeyAsync(string key) => _storageProvider.ContainKeyAsync(key);

        public async ValueTask<T> GetItemAsync<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            var serializedData = await _storageProvider.GetItemAsync(key).ConfigureAwait(false);
            try
            {
                return JsonSerializer.Deserialize<T>(serializedData);
            }
            catch (JsonException e) when (e.Path == "$" && typeof(T) == typeof(string))
            {
                // For backward compatibility return the plain string.
                // On the next save a correct value will be stored and this Exception will not happen again, for this 'key'
                return (T)(object)serializedData;
            }
        }

        public ValueTask<string> KeyAsync(int index) => _storageProvider.KeyAsync(index);

        public ValueTask<string> GetItemAsStringAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            return _storageProvider.GetItemAsync(key);
        }

        public ValueTask<int> LengthAsync() => _storageProvider.LengthAsync();

        public ValueTask RemoveItemAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            return _storageProvider.RemoveItemAsync(key);
        }

        public async ValueTask SetItemAsync<T>(string key, T data)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            var serializedData = JsonSerializer.Serialize(data);
            await _storageProvider.SetItemAsync(key, serializedData).ConfigureAwait(false);
        }

        public async ValueTask SetItemAsStringAsync(string key, string data)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            if (data is null) throw new ArgumentNullException(nameof(data));
            await _storageProvider.SetItemAsync(key, data).ConfigureAwait(false);
        }
    }

    public class SessionStorageService : BrowserStorageService, ISessionStorageService
    {
        public SessionStorageService(ISessionStorageProvider storageProvider) : base(storageProvider) { }
    }

    public class LocalStorageService : BrowserStorageService, ILocalStorageService
    {
        public LocalStorageService(ILocalStorageProvider storageProvider) : base(storageProvider) { }
    }
}
