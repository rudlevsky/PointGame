using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPointGame.GenericTypes
{
    /// <summary>
    /// Minimal realization which message should have.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Message<TContent> : IDisposable
    {
		private bool _isDisposed;

		/// <summary>
		/// A container which has our message data.
		/// </summary>
		public TContent Content { get; }

        public Message(TContent data)
        {
            Content = data;
        }

		/// <summary>
		/// Dipose the <see cref="Message{TContent}"/>.
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
		}

		/// <summary>
		/// The logic of disposing the <see cref="Message{TContent}"/>.
		/// </summary>
		/// <param name="flag">
		/// <c>true</c> if is called from <see cref="Dispose"/>.
		/// <c>false</c> if from <see cref="GC"/>.
		/// </param>
		protected virtual void Dispose(bool flag)
		{
			if (_isDisposed) return;
			if (flag) GC.SuppressFinalize(this);
			this._isDisposed = true;
		}

		~Message()
		{
			Dispose(false);
		}
    }
}
