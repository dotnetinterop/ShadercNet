namespace DotNetInterop.ShadercNet
{
    public enum shaderc_shader_kind
    {
        // Forced shader kinds. These shader kinds force the compiler to compile the
        // source code as the specified kind of shader.
        shaderc_vertex_shader,
        shaderc_fragment_shader,
        shaderc_compute_shader,
        shaderc_geometry_shader,
        shaderc_tess_control_shader,
        shaderc_tess_evaluation_shader,

        shaderc_glsl_vertex_shader = shaderc_vertex_shader,
        shaderc_glsl_fragment_shader = shaderc_fragment_shader,
        shaderc_glsl_compute_shader = shaderc_compute_shader,
        shaderc_glsl_geometry_shader = shaderc_geometry_shader,
        shaderc_glsl_tess_control_shader = shaderc_tess_control_shader,
        shaderc_glsl_tess_evaluation_shader = shaderc_tess_evaluation_shader,

        // Deduce the shader kind from #pragma annotation in the source code. Compiler
        // will emit error if #pragma annotation is not found.
        shaderc_glsl_infer_from_source,
        // Default shader kinds. Compiler will fall back to compile the source code as
        // the specified kind of shader when #pragma annotation is not found in the
        // source code.
        shaderc_glsl_default_vertex_shader,
        shaderc_glsl_default_fragment_shader,
        shaderc_glsl_default_compute_shader,
        shaderc_glsl_default_geometry_shader,
        shaderc_glsl_default_tess_control_shader,
        shaderc_glsl_default_tess_evaluation_shader,
        shaderc_spirv_assembly,
        shaderc_raygen_shader,
        shaderc_anyhit_shader,
        shaderc_closesthit_shader,
        shaderc_miss_shader,
        shaderc_intersection_shader,
        shaderc_callable_shader,
        shaderc_glsl_raygen_shader = shaderc_raygen_shader,
        shaderc_glsl_anyhit_shader = shaderc_anyhit_shader,
        shaderc_glsl_closesthit_shader = shaderc_closesthit_shader,
        shaderc_glsl_miss_shader = shaderc_miss_shader,
        shaderc_glsl_intersection_shader = shaderc_intersection_shader,
        shaderc_glsl_callable_shader = shaderc_callable_shader,
        shaderc_glsl_default_raygen_shader,
        shaderc_glsl_default_anyhit_shader,
        shaderc_glsl_default_closesthit_shader,
        shaderc_glsl_default_miss_shader,
        shaderc_glsl_default_intersection_shader,
        shaderc_glsl_default_callable_shader,
        shaderc_task_shader,
        shaderc_mesh_shader,
        shaderc_glsl_task_shader = shaderc_task_shader,
        shaderc_glsl_mesh_shader = shaderc_mesh_shader,
        shaderc_glsl_default_task_shader,
        shaderc_glsl_default_mesh_shader,
    }
}
