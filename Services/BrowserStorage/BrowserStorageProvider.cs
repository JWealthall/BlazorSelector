using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorSelector.Services
{
    public interface IBrowserStorageProvider
    {
        void Clear();
        ValueTask ClearAsync(CancellationToken? cancellationToken = null);
        bool ContainKey(string key);
        ValueTask<bool> ContainKeyAsync(string key, CancellationToken? cancellationToken = null);
        string GetItem(string key);
        ValueTask<string> GetItemAsync(string key, CancellationToken? cancellationToken = null);
        byte[] GetItemAsBytes(string key);
        ValueTask<byte[]> GetItemAsBytesAsync(string key, CancellationToken? cancellationToken = null);
        string Key(int index);
        ValueTask<string> KeyAsync(int index, CancellationToken? cancellationToken = null);
        int Length();
        ValueTask<int> LengthAsync(CancellationToken? cancellationToken = null);
        void RemoveItem(string key);
        ValueTask RemoveItemAsync(string key, CancellationToken? cancellationToken = null);
        void SetItem(string key, string data);
        ValueTask SetItemAsync(string key, string data, CancellationToken? cancellationToken = null);
        void SetItem(string key, byte[] data);
        ValueTask SetItemAsync(string key, byte[] data, CancellationToken? cancellationToken = null);
    }

    public interface ILocalStorageProvider : IBrowserStorageProvider { }
    public interface ISessionStorageProvider : IBrowserStorageProvider { }

    public abstract class BrowserStorageProvider : IBrowserStorageProvider
    {
        private readonly IJSRuntime _jSRuntime;
        private readonly IJSInProcessRuntime _jSInProcessRuntime;
        private readonly string _store;

        protected BrowserStorageProvider(IJSRuntime jSRuntime, string store)
        {
            _jSRuntime = jSRuntime;
            _jSInProcessRuntime = jSRuntime as IJSInProcessRuntime;
            _store = store;
        }

        public ValueTask ClearAsync(CancellationToken? cancellationToken = null)
            => _jSRuntime.InvokeVoidAsync(_store + ".clear", cancellationToken ?? CancellationToken.None);

        public ValueTask<string> GetItemAsync(string key, CancellationToken? cancellationToken = null)
            => _jSRuntime.InvokeAsync<string>(_store + ".getItem", cancellationToken ?? CancellationToken.None, key);

        public async ValueTask<byte[]> GetItemAsBytesAsync(string key, CancellationToken? cancellationToken = null)
        {
            var data = await _jSRuntime.InvokeAsync<string>(_store + ".getItem", cancellationToken ?? CancellationToken.None, key);
            return Convert.FromBase64String(data);
        }

        public ValueTask<string> KeyAsync(int index, CancellationToken? cancellationToken = null)
            => _jSRuntime.InvokeAsync<string>(_store + ".key", cancellationToken ?? CancellationToken.None, index);

        public ValueTask<bool> ContainKeyAsync(string key, CancellationToken? cancellationToken = null)
            => _jSRuntime.InvokeAsync<bool>(_store + ".hasOwnProperty", cancellationToken ?? CancellationToken.None, key);

        public ValueTask<int> LengthAsync(CancellationToken? cancellationToken = null)
            => _jSRuntime.InvokeAsync<int>("eval", cancellationToken ?? CancellationToken.None, _store + ".length");

        public ValueTask RemoveItemAsync(string key, CancellationToken? cancellationToken = null)
            => _jSRuntime.InvokeVoidAsync(_store + ".removeItem", cancellationToken ?? CancellationToken.None, key);

        public ValueTask SetItemAsync(string key, string data, CancellationToken? cancellationToken = null)
            => _jSRuntime.InvokeVoidAsync(_store + ".setItem", cancellationToken ?? CancellationToken.None, key, data);

        public ValueTask SetItemAsync(string key, byte[] data, CancellationToken? cancellationToken = null)
            => _jSRuntime.InvokeVoidAsync(_store + ".setItem", cancellationToken ?? CancellationToken.None, key, Convert.ToBase64String(data));

        public void Clear()
        {
            CheckForInProcessRuntime();
            _jSInProcessRuntime.InvokeVoid(_store + ".clear");
        }

        public string GetItem(string key)
        {
            CheckForInProcessRuntime();
            return _jSInProcessRuntime.Invoke<string>(_store + ".getItem", key);
        }

        public byte[] GetItemAsBytes(string key)
        {
            CheckForInProcessRuntime();
            return _jSInProcessRuntime.Invoke<byte[]>(_store + ".getItem", key);
        }

        public string Key(int index)
        {
            CheckForInProcessRuntime();
            return _jSInProcessRuntime.Invoke<string>(_store + ".key", index);
        }

        public bool ContainKey(string key)
        {
            CheckForInProcessRuntime();
            return _jSInProcessRuntime.Invoke<bool>(_store + ".hasOwnProperty", key);
        }

        public int Length()
        {
            CheckForInProcessRuntime();
            return _jSInProcessRuntime.Invoke<int>("eval", _store + ".length");
        }

        public void RemoveItem(string key)
        {
            CheckForInProcessRuntime();
            _jSInProcessRuntime.InvokeVoidAsync(_store + ".removeItem", key);
        }

        public void SetItem(string key, string data)
        {
            CheckForInProcessRuntime();
            _jSInProcessRuntime.InvokeVoid(_store + ".setItem", key, data);
        }

        public void SetItem(string key, byte[] data)
        {
            CheckForInProcessRuntime();
            _jSInProcessRuntime.InvokeVoid(_store + ".setItem", key, data);
        }

        private void CheckForInProcessRuntime()
        {
            if (_jSInProcessRuntime == null)
                throw new InvalidOperationException("IJSInProcessRuntime not available");
        }
    }

    internal class LocalStorageProvider : BrowserStorageProvider, ILocalStorageProvider
    {
        public LocalStorageProvider(IJSRuntime jSRuntime) : base(jSRuntime, "localStorage") { }
    }

    internal class SessionStorageProvider : BrowserStorageProvider, ISessionStorageProvider
    {
        public SessionStorageProvider(IJSRuntime jSRuntime) : base(jSRuntime, "sessionStorage") { }
    }
}
