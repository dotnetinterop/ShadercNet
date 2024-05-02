using System.Text;

namespace DotNetInterop.ShadercNet
{
    public unsafe class CompileOptions : IDisposable, ICloneable
    {
        private bool disposed;
        private shaderc_compile_options* options;

        internal shaderc_compile_options* Handle => this.options;

        internal CompileOptions(shaderc_compile_options* options)
        {
            this.disposed = false;
            this.options = options;
        }

        public CompileOptions()
            : this(ShadercShared.shaderc_compile_options_initialize())
        {
        }

        public void AddMacroDefinition(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            fixed (byte* namePtr = Encoding.UTF8.GetBytes(name))
            {
                ShadercShared.shaderc_compile_options_add_macro_definition(
                    this.options,
                    (sbyte*)namePtr,
                    (nuint)name.Length,
                    null,
                    0U
                );
            }
        }

        public void AddMacroDefinition(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value));

            fixed (byte* namePtr = Encoding.UTF8.GetBytes(name))
            {
                fixed (byte* valuePtr = Encoding.UTF8.GetBytes(value))
                {
                    ShadercShared.shaderc_compile_options_add_macro_definition(
                        this.options,
                        (sbyte*)namePtr,
                        (nuint)name.Length,
                        (sbyte*)valuePtr,
                        (nuint)value.Length
                    );
                }
            }
        }

        public void SetGenerateDebugInfo()
        {
            ShadercShared.shaderc_compile_options_set_generate_debug_info(this.options);
        }

        public shaderc_optimization_level OptimizationLevel
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_optimization_level(this.options, value);
            }
        }

        //includer

        public void SetForcedVersionProfile(int version, shaderc_profile profile)
        {
            ShadercShared.shaderc_compile_options_set_forced_version_profile(this.options, version, profile);
        }

        public void SetSuppressWarnings()
        {
            ShadercShared.shaderc_compile_options_set_suppress_warnings(this.options);
        }

        public shaderc_source_language SourceLanguage
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_source_language(this.options, value);
            }
        }

        public void SetTargetEnvironment(shaderc_target_env target, uint version)
        {
            ShadercShared.shaderc_compile_options_set_target_env(this.options, target, version);
        }

        public shaderc_spirv_version TargetSpirv
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_target_spirv(this.options, value);
            }
        }

        public void SetWarningsAsErrors()
        {
            ShadercShared.shaderc_compile_options_set_warnings_as_errors(this.options);
        }

        public void SetLimit(shaderc_limit limit, int value)
        {
            ShadercShared.shaderc_compile_options_set_limit(this.options, limit, value);
        }

        public bool AutoBindUniforms
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_auto_bind_uniforms(this.options, (byte)(value ? 1 : 0));
            }
        }

        public bool AutoSampledTextures
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_auto_combined_image_sampler(this.options, (byte)(value ? 1 : 0));
            }
        }

        public bool HlslIoMapping
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_hlsl_io_mapping(this.options, (byte)(value ? 1 : 0));
            }
        }

        public bool HlslOffsets
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_hlsl_offsets(this.options, (byte)(value ? 1 : 0));
            }
        }

        public void SetBindingBase(shaderc_uniform_kind kind, uint @base)
        {
            ShadercShared.shaderc_compile_options_set_binding_base(this.options, kind, @base);
        }

        public void SetBindingBaseForStage(shaderc_shader_kind shader_kind, shaderc_uniform_kind kind, uint @base)
        {
            ShadercShared.shaderc_compile_options_set_binding_base_for_stage(this.options, shader_kind, kind, @base);
        }

        public bool PreserveBindings
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_preserve_bindings(this.options, (byte)(value ? 1 : 0));
            }
        }

        public bool AutoMapLocations
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_auto_map_locations(this.options, (byte)(value ? 1 : 0));
            }
        }

        public void SetHlslRegisterSetAndBindingForStage(shaderc_shader_kind shader_kind, string reg, string set, string binding)
        {
            if (string.IsNullOrWhiteSpace(reg))
                throw new ArgumentNullException(nameof(reg));
            
            if (string.IsNullOrWhiteSpace(set))
                throw new ArgumentNullException(nameof(set));
            
            if (string.IsNullOrWhiteSpace(binding))
                throw new ArgumentNullException(nameof(binding));

            fixed (byte* regPtr = Encoding.UTF8.GetBytes(reg))
            {
                fixed (byte* setPtr = Encoding.UTF8.GetBytes(set))
                {
                    fixed (byte* bindingPtr = Encoding.UTF8.GetBytes(binding))
                    {
                        ShadercShared.shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage(
                            this.options,
                            shader_kind,
                            (sbyte*)regPtr,
                            (sbyte*)setPtr,
                            (sbyte*)bindingPtr
                        );
                    }
                }
            }
        }

        public void SetHlslRegisterSetAndBinding(string reg, string set, string binding)
        {
            if (string.IsNullOrWhiteSpace(reg))
                throw new ArgumentNullException(nameof(reg));

            if (string.IsNullOrWhiteSpace(set))
                throw new ArgumentNullException(nameof(set));

            if (string.IsNullOrWhiteSpace(binding))
                throw new ArgumentNullException(nameof(binding));

            fixed (byte* regPtr = Encoding.UTF8.GetBytes(reg))
            {
                fixed (byte* setPtr = Encoding.UTF8.GetBytes(set))
                {
                    fixed (byte* bindingPtr = Encoding.UTF8.GetBytes(binding))
                    {
                        ShadercShared.shaderc_compile_options_set_hlsl_register_set_and_binding(
                            this.options,
                            (sbyte*)regPtr,
                            (sbyte*)setPtr,
                            (sbyte*)bindingPtr
                        );
                    }
                }
            }
        }

        public bool HlslFunctionality1
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_hlsl_functionality1(this.options, (byte)(value ? 1 : 0));
            }
        }

        public bool Hlsl16BitTypes
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_hlsl_16bit_types(this.options, (byte)(value ? 1 : 0));
            }
        }

        public bool VulkanRulesRelaxed
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_vulkan_rules_relaxed(this.options, (byte)(value ? 1 : 0));
            }
        }

        public bool InvertY
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_invert_y(this.options, (byte)(value ? 1 : 0));
            }
        }

        public bool NanClamp
        {
            set
            {
                ShadercShared.shaderc_compile_options_set_nan_clamp(this.options, (byte)(value ? 1 : 0));
            }
        }

        public object Clone()
        {
            return new CompileOptions(ShadercShared.shaderc_compile_options_clone(this.options));
        }

        private void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            if (disposing)
                GC.SuppressFinalize(this);

            ShadercShared.shaderc_compile_options_release(this.options);

            this.options = null;
            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        ~CompileOptions()
        {
            this.Dispose(false);
        }
    }
}
