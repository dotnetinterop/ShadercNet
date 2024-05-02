using System.Text;

namespace DotNetInterop.ShadercNet
{
    public unsafe class Compiler : IDisposable
    {
        private bool disposed;
        private shaderc_compiler* compiler;

        internal shaderc_compiler* Handle => this.compiler;

        public bool IsValid => this.compiler != null;

        internal Compiler(shaderc_compiler* compiler)
        {
            this.disposed = false;
            this.compiler = compiler;
        }

        public Compiler()
            : this(ShadercShared.shaderc_compiler_initialize())
        {
        }

        public CompilationResult CompileGlslToSpv(string source, shaderc_shader_kind shaderKind, string inputFileName, string entryPointName, CompileOptions? options)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrWhiteSpace(inputFileName))
                throw new ArgumentNullException(nameof(inputFileName));

            if (string.IsNullOrWhiteSpace(entryPointName))
                throw new ArgumentNullException(nameof(entryPointName));

            fixed (byte* sourcePtr = Encoding.UTF8.GetBytes(source))
            {
                fixed (byte* inputFileNamePtr = Encoding.UTF8.GetBytes(inputFileName))
                {
                    fixed (byte* entryPointNamePtr = Encoding.UTF8.GetBytes(entryPointName))
                    {
                        return new CompilationResult(
                            ShadercShared.shaderc_compile_into_spv(
                                this.compiler,
                                (sbyte*)sourcePtr,
                                (nuint)source.Length,
                                shaderKind,
                                (sbyte*)inputFileNamePtr,
                                (sbyte*)entryPointNamePtr,
                                options == null ? null : options.Handle
                            )
                        );
                    }
                }
            }
        }

        public CompilationResult CompileGlslToSpv(string source, shaderc_shader_kind shaderKind, string inputFileName, CompileOptions? options)
        {
            return this.CompileGlslToSpv(source, shaderKind, inputFileName, "main", options);
        }

        public CompilationResult CompileGlslToSpv(string source, shaderc_shader_kind shaderKind, string inputFileName)
        {
            return this.CompileGlslToSpv(source, shaderKind, inputFileName, null);
        }

        public CompilationResult AssembleToSpv(string source, CompileOptions? options)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException(nameof(source));

            fixed (byte* sourcePtr = Encoding.UTF8.GetBytes(source))
            {
                return new CompilationResult(
                    ShadercShared.shaderc_assemble_into_spv(
                        this.compiler,
                        (sbyte*)sourcePtr,
                        (nuint)source.Length,
                        options == null ? null : options.Handle
                    )
                );
            }
        }

        public CompilationResult AssembleToSpv(string source)
        {
            return this.AssembleToSpv(source, null);
        }

        public CompilationResult CompileGlslToSpvAssembly(string source, shaderc_shader_kind shaderKind, string inputFileName, string entryPointName, CompileOptions options)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrWhiteSpace(inputFileName))
                throw new ArgumentNullException(nameof(inputFileName));

            if (string.IsNullOrWhiteSpace(entryPointName))
                throw new ArgumentNullException(nameof(entryPointName));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            fixed (byte* sourcePtr = Encoding.UTF8.GetBytes(source))
            {
                fixed (byte* inputFileNamePtr = Encoding.UTF8.GetBytes(inputFileName))
                {
                    fixed (byte* entryPointNamePtr = Encoding.UTF8.GetBytes(entryPointName))
                    {
                        return new CompilationResult(
                            ShadercShared.shaderc_compile_into_spv_assembly(
                                this.compiler,
                                (sbyte*)sourcePtr,
                                (nuint)source.Length,
                                shaderKind,
                                (sbyte*)inputFileNamePtr,
                                (sbyte*)entryPointNamePtr,
                                options.Handle
                            )
                        );
                    }
                }
            }
        }

        public CompilationResult CompileGlslToSpvAssembly(string source, shaderc_shader_kind shaderKind, string inputFileName, CompileOptions options)
        {
            return this.CompileGlslToSpvAssembly(source, shaderKind, inputFileName, "main", options);
        }

        public CompilationResult PreprocessGlsl(string source, shaderc_shader_kind shaderKind, string inputFileName, string entryPointName, CompileOptions options)
        {
            if (string.IsNullOrWhiteSpace(source))
                throw new ArgumentNullException(nameof(source));

            if (string.IsNullOrWhiteSpace(inputFileName))
                throw new ArgumentNullException(nameof(inputFileName));

            if (string.IsNullOrWhiteSpace(entryPointName))
                throw new ArgumentNullException(nameof(entryPointName));

            if (options == null)
                throw new ArgumentNullException(nameof(options));

            fixed (byte* sourcePtr = Encoding.UTF8.GetBytes(source))
            {
                fixed (byte* inputFileNamePtr = Encoding.UTF8.GetBytes(inputFileName))
                {
                    fixed (byte* entryPointNamePtr = Encoding.UTF8.GetBytes(entryPointName))
                    {
                        return new CompilationResult(
                            ShadercShared.shaderc_compile_into_preprocessed_text(
                                this.compiler,
                                (sbyte*)sourcePtr,
                                (nuint)source.Length,
                                shaderKind,
                                (sbyte*)inputFileNamePtr,
                                (sbyte*)entryPointNamePtr,
                                options.Handle
                            )
                        );
                    }
                }
            }
        }

        public CompilationResult PreprocessGlsl(string source, shaderc_shader_kind shaderKind, string inputFileName, CompileOptions options)
        {
            return this.PreprocessGlsl(source, shaderKind, inputFileName, "main", options);
        }

        private void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
                GC.SuppressFinalize(this);

            ShadercShared.shaderc_compiler_release(this.compiler);

            this.compiler = null;
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        ~Compiler()
        {
            this.Dispose(false);
        }
    }
}
