using System;

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
        /// Class's constructor.
        /// </summary>
        /// <param name="data">Passed data.</param>
        public Message(TContent data)
        {
            Content = data;
        }

        /// <summary>
        /// A container which has our message data.
        /// </summary>
        public TContent Content { get; }

        /// <summary>
        /// Dispose the <see cref="Message{TContent}"/>.
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

        /// <summary>
        /// Dispose destructor.
        /// </summary>
		~Message()
		{
			Dispose(false);
		}
    }
}
