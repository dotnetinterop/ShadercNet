using System.Text;

namespace DotNetInterop.ShadercNet.Test
{
    public class CompilerTest
    {
        [Theory]
        [InlineData("GLSL_Renderer2D_Quad_Vertex", shaderc_shader_kind.shaderc_glsl_vertex_shader)]
        [InlineData("GLSL_Renderer2D_Quad_Fragment", shaderc_shader_kind.shaderc_glsl_fragment_shader)]
        public void TestCompileGlslToSpv(string resourceName, shaderc_shader_kind shaderKind)
        {
            using (var options = new CompileOptions())
            {
                options.SetTargetEnvironment(shaderc_target_env.shaderc_target_env_vulkan, (uint)shaderc_env_version.shaderc_env_version_vulkan_1_3);
                options.OptimizationLevel = shaderc_optimization_level.shaderc_optimization_level_performance;
                using (var compiler = new Compiler())
                {
                    var bytes = Properties.Resources.ResourceManager.GetObject(resourceName) as byte[];
                    if(bytes == null)
                        Assert.Fail($"Resource '{resourceName}' not found!");

                    using (var result = compiler.CompileGlslToSpv(Encoding.UTF8.GetString(bytes), shaderKind, $"{resourceName}.shader", options))
                    {
                        if (result.CompilationStatus != shaderc_compilation_status.shaderc_compilation_status_success)
                            Assert.Fail($"Compilation failed! Status: {result.CompilationStatus}; Message: {result.ErrorMessage}");
                    }
                }
            }
        }

        [Theory]
        [InlineData("GLSL_Renderer2D_Quad_Vertex", shaderc_shader_kind.shaderc_glsl_vertex_shader)]
        [InlineData("GLSL_Renderer2D_Quad_Fragment", shaderc_shader_kind.shaderc_glsl_fragment_shader)]
        public void TestPreprocessGlsl(string resourceName, shaderc_shader_kind shaderKind)
        {
            using (var options = new CompileOptions())
            {
                options.SetTargetEnvironment(shaderc_target_env.shaderc_target_env_vulkan, (uint)shaderc_env_version.shaderc_env_version_vulkan_1_3);
                options.OptimizationLevel = shaderc_optimization_level.shaderc_optimization_level_performance;
                using (var compiler = new Compiler())
                {
                    var bytes = Properties.Resources.ResourceManager.GetObject(resourceName) as byte[];
                    if (bytes == null)
                        Assert.Fail($"Resource '{resourceName}' not found!");

                    using (var result = compiler.PreprocessGlsl(Encoding.UTF8.GetString(bytes), shaderKind, $"{resourceName}.shader", options))
                    {
                        if (result.CompilationStatus != shaderc_compilation_status.shaderc_compilation_status_success)
                            Assert.Fail($"Compilation failed! Status: {result.CompilationStatus}; Message: {result.ErrorMessage}");
                    }
                }
            }
        }

        [Theory]
        [InlineData("GLSL_Renderer2D_Quad_Vertex", shaderc_shader_kind.shaderc_glsl_vertex_shader)]
        [InlineData("GLSL_Renderer2D_Quad_Fragment", shaderc_shader_kind.shaderc_glsl_fragment_shader)]
        public void TestCompileGlslToSpvAssembly(string resourceName, shaderc_shader_kind shaderKind)
        {
            using (var options = new CompileOptions())
            {
                options.SetTargetEnvironment(shaderc_target_env.shaderc_target_env_vulkan, (uint)shaderc_env_version.shaderc_env_version_vulkan_1_3);
                options.OptimizationLevel = shaderc_optimization_level.shaderc_optimization_level_performance;
                using (var compiler = new Compiler())
                {
                    var bytes = Properties.Resources.ResourceManager.GetObject(resourceName) as byte[];
                    if (bytes == null)
                        Assert.Fail($"Resource '{resourceName}' not found!");

                    using (var result = compiler.CompileGlslToSpvAssembly(Encoding.UTF8.GetString(bytes), shaderKind, $"{resourceName}.shader", options))
                    {
                        if (result.CompilationStatus != shaderc_compilation_status.shaderc_compilation_status_success)
                            Assert.Fail($"Compilation failed! Status: {result.CompilationStatus}; Message: {result.ErrorMessage}");
                    }
                }
            }
        }

        [Theory]
        [InlineData("SPVA_Renderer2D_Quad_Vertex")]
        [InlineData("SPVA_Renderer2D_Quad_Fragment")]
        public void TestAssembleToSpv(string resourceName)
        {
            using (var options = new CompileOptions())
            {
                options.SetTargetEnvironment(shaderc_target_env.shaderc_target_env_vulkan, (uint)shaderc_env_version.shaderc_env_version_vulkan_1_3);
                options.OptimizationLevel = shaderc_optimization_level.shaderc_optimization_level_performance;
                using (var compiler = new Compiler())
                {
                    var bytes = Properties.Resources.ResourceManager.GetObject(resourceName) as byte[];
                    if (bytes == null)
                        Assert.Fail($"Resource '{resourceName}' not found!");

                    using (var result = compiler.AssembleToSpv(Encoding.UTF8.GetString(bytes), options))
                    {
                        if (result.CompilationStatus != shaderc_compilation_status.shaderc_compilation_status_success)
                            Assert.Fail($"Compilation failed! Status: {result.CompilationStatus}; Message: {result.ErrorMessage}");
                    }
                }
            }
        }
    }
}