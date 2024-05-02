using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetInterop.ShadercNet
{
    public unsafe class CompilationResult : IDisposable
    {
        private bool disposed;
        private shaderc_compilation_result* compilationResult;

        internal shaderc_compilation_result* Handle => this.compilationResult;

        internal CompilationResult(shaderc_compilation_result* compilationResult)
        {
            this.disposed = false;
            this.compilationResult = compilationResult;
        }

        public string ErrorMessage
        {
            get
            {
                if (this.compilationResult == null)
                    return "";

                return new string(ShadercShared.shaderc_result_get_error_message(this.compilationResult));
            }
        }

        public shaderc_compilation_status CompilationStatus
        {
            get
            {
                if (this.compilationResult == null)
                    return shaderc_compilation_status.shaderc_compilation_status_null_result_object;

                return ShadercShared.shaderc_result_get_compilation_status(this.compilationResult);
            }
        }

        public byte[]? Bytes
        {
            get
            {
                if (this.compilationResult == null)
                    return null;

                nuint length = ShadercShared.shaderc_result_get_length(this.compilationResult);
                sbyte* bytePtr = ShadercShared.shaderc_result_get_bytes(this.compilationResult);

                var bytes = new byte[length];
                fixed (byte* pBytes = bytes)
                    Unsafe.CopyBlock(pBytes, bytePtr, (uint)length);

                return bytes;
            }
        }

        public int Length
        {
            get
            {
                if (this.compilationResult == null)
                    return 0;
                
                return (int)ShadercShared.shaderc_result_get_length(this.compilationResult);
            }
        }

        public int WarningsCount
        {
            get
            {
                if (this.compilationResult == null)
                    return 0;

                return (int)ShadercShared.shaderc_result_get_num_warnings(this.compilationResult);
            }
        }

        public int ErrorsCount
        {
            get
            {
                if (this.compilationResult == null)
                    return 0;

                return (int)ShadercShared.shaderc_result_get_num_errors(this.compilationResult);
            }
        }

        private void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
                GC.SuppressFinalize(this);

            ShadercShared.shaderc_result_release(this.compilationResult);

            this.compilationResult = null;
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        ~CompilationResult()
        {
            this.Dispose(false);
        }
    }
}
