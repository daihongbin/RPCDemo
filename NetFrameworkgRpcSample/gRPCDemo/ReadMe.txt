//https://www.cnblogs.com/linezero/p/grpc.html
//编译生成类文件命令
packages\Grpc.Tools.1.0.0\tools\windows_x86\protoc.exe -IgRPCDemo --csharp_out gRPCDemo  gRPCDemo\helloworld.proto --grpc_out gRPCDemo --plugin=protoc-gen-grpc=packages\Grpc.Tools.1.0.0\tools\windows_x86\grpc_csharp_plugin.exe