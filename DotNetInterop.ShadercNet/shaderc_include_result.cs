namespace DotNetInterop.ShadercNet
{
    public unsafe partial struct shaderc_include_result
    {
        public sbyte* source_name;

        public nuint source_name_length;

        public sbyte* content;

        public nuint content_length;

        public void* user_data;
    }
}
