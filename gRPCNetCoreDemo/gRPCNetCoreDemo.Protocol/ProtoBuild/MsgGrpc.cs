// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: msg.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GRPCNetCoreDemo.Protocol {
  public static partial class MsgService
  {
    static readonly string __ServiceName = "gRPCNetCoreDemo.Protocol.MsgService";

    static readonly grpc::Marshaller<global::GRPCNetCoreDemo.Protocol.GetMsgNumRequest> __Marshaller_gRPCNetCoreDemo_Protocol_GetMsgNumRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GRPCNetCoreDemo.Protocol.GetMsgNumRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GRPCNetCoreDemo.Protocol.GetMsgSumReply> __Marshaller_gRPCNetCoreDemo_Protocol_GetMsgSumReply = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GRPCNetCoreDemo.Protocol.GetMsgSumReply.Parser.ParseFrom);

    static readonly grpc::Method<global::GRPCNetCoreDemo.Protocol.GetMsgNumRequest, global::GRPCNetCoreDemo.Protocol.GetMsgSumReply> __Method_GetSum = new grpc::Method<global::GRPCNetCoreDemo.Protocol.GetMsgNumRequest, global::GRPCNetCoreDemo.Protocol.GetMsgSumReply>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetSum",
        __Marshaller_gRPCNetCoreDemo_Protocol_GetMsgNumRequest,
        __Marshaller_gRPCNetCoreDemo_Protocol_GetMsgSumReply);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GRPCNetCoreDemo.Protocol.MsgReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of MsgService</summary>
    [grpc::BindServiceMethod(typeof(MsgService), "BindService")]
    public abstract partial class MsgServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::GRPCNetCoreDemo.Protocol.GetMsgSumReply> GetSum(global::GRPCNetCoreDemo.Protocol.GetMsgNumRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(MsgServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetSum, serviceImpl.GetSum).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, MsgServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetSum, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GRPCNetCoreDemo.Protocol.GetMsgNumRequest, global::GRPCNetCoreDemo.Protocol.GetMsgSumReply>(serviceImpl.GetSum));
    }

  }
}
#endregion