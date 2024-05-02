using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetInterop.ShadercNet
{
    public static unsafe class ShadercShared
    {
        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern shaderc_compiler* shaderc_compiler_initialize();

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compiler_release(shaderc_compiler* param0);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern shaderc_compile_options* shaderc_compile_options_initialize();

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern shaderc_compile_options* shaderc_compile_options_clone(shaderc_compile_options* options);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_release(shaderc_compile_options* options);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_add_macro_definition(shaderc_compile_options* options, sbyte* name, nuint name_length, sbyte* value, nuint value_length);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_source_language(shaderc_compile_options* options, shaderc_source_language lang);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_generate_debug_info(shaderc_compile_options* options);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_optimization_level(shaderc_compile_options* options, shaderc_optimization_level level);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_forced_version_profile(shaderc_compile_options* options, int version, shaderc_profile profile);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_include_callbacks(shaderc_compile_options* options, delegate* unmanaged[Cdecl]<void*, sbyte*, int, sbyte*, nuint, shaderc_include_result*> resolver, delegate* unmanaged[Cdecl]<void*, shaderc_include_result*, void> result_releaser, void* user_data);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_suppress_warnings(shaderc_compile_options* options);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_target_env(shaderc_compile_options* options, shaderc_target_env target, uint version);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_target_spirv(shaderc_compile_options* options, shaderc_spirv_version version);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_warnings_as_errors(shaderc_compile_options* options);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_limit(shaderc_compile_options* options, shaderc_limit limit, int value);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_auto_bind_uniforms(shaderc_compile_options* options, byte auto_bind);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_auto_combined_image_sampler(shaderc_compile_options* options, byte upgrade);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_hlsl_io_mapping(shaderc_compile_options* options, byte hlsl_iomap);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_hlsl_offsets(shaderc_compile_options* options, byte hlsl_offsets);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_binding_base(shaderc_compile_options* options, shaderc_uniform_kind kind, uint @base);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_binding_base_for_stage(shaderc_compile_options* options, shaderc_shader_kind shader_kind, shaderc_uniform_kind kind, uint @base);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_preserve_bindings(shaderc_compile_options* options, byte preserve_bindings);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_auto_map_locations(shaderc_compile_options* options, byte auto_map);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_hlsl_register_set_and_binding_for_stage(shaderc_compile_options* options, shaderc_shader_kind shader_kind, sbyte* reg, sbyte* set, sbyte* binding);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_hlsl_register_set_and_binding(shaderc_compile_options* options, sbyte* reg, sbyte* set, sbyte* binding);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_hlsl_functionality1(shaderc_compile_options* options, byte enable);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_hlsl_16bit_types(shaderc_compile_options* options, byte enable);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_vulkan_rules_relaxed(shaderc_compile_options* options, byte enable);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_invert_y(shaderc_compile_options* options, byte enable);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_compile_options_set_nan_clamp(shaderc_compile_options* options, byte enable);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern shaderc_compilation_result* shaderc_compile_into_spv(shaderc_compiler* compiler, sbyte* source_text, nuint source_text_size, shaderc_shader_kind shader_kind, sbyte* input_file_name, sbyte* entry_point_name, shaderc_compile_options* additional_options);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern shaderc_compilation_result* shaderc_compile_into_spv_assembly(shaderc_compiler* compiler, sbyte* source_text, nuint source_text_size, shaderc_shader_kind shader_kind, sbyte* input_file_name, sbyte* entry_point_name, shaderc_compile_options* additional_options);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern shaderc_compilation_result* shaderc_compile_into_preprocessed_text(shaderc_compiler* compiler, sbyte* source_text, nuint source_text_size, shaderc_shader_kind shader_kind, sbyte* input_file_name, sbyte* entry_point_name, shaderc_compile_options* additional_options);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern shaderc_compilation_result* shaderc_assemble_into_spv(shaderc_compiler* compiler, sbyte* source_assembly, nuint source_assembly_size, shaderc_compile_options* additional_options);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_result_release(shaderc_compilation_result* result);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern nuint shaderc_result_get_length(shaderc_compilation_result* result);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern nuint shaderc_result_get_num_warnings(shaderc_compilation_result* result);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern nuint shaderc_result_get_num_errors(shaderc_compilation_result* result);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern shaderc_compilation_status shaderc_result_get_compilation_status(shaderc_compilation_result* param0);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern sbyte* shaderc_result_get_bytes(shaderc_compilation_result* result);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern sbyte* shaderc_result_get_error_message(shaderc_compilation_result* result);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void shaderc_get_spv_version(uint* version, uint* revision);

        [DllImport("shaderc_shared", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern byte shaderc_parse_version_profile(sbyte* str, int* version, shaderc_profile* profile);
    }

}
