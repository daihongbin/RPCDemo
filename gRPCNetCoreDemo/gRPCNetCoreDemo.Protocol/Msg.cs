// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: msg.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GRPCNetCoreDemo.Protocol {

  /// <summary>Holder for reflection information generated from msg.proto</summary>
  public static partial class MsgReflection {

    #region Descriptor
    /// <summary>File descriptor for msg.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static MsgReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Cgltc2cucHJvdG8SGGdSUENOZXRDb3JlRGVtby5Qcm90b2NvbCIuChBHZXRN",
            "c2dOdW1SZXF1ZXN0EgwKBE51bTEYASABKAUSDAoETnVtMhgCIAEoBSIdCg5H",
            "ZXRNc2dTdW1SZXBseRILCgNTdW0YASABKAUybgoKTXNnU2VydmljZRJgCgZH",
            "ZXRTdW0SKi5nUlBDTmV0Q29yZURlbW8uUHJvdG9jb2wuR2V0TXNnTnVtUmVx",
            "dWVzdBooLmdSUENOZXRDb3JlRGVtby5Qcm90b2NvbC5HZXRNc2dTdW1SZXBs",
            "eSIAYgZwcm90bzM="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GRPCNetCoreDemo.Protocol.GetMsgNumRequest), global::GRPCNetCoreDemo.Protocol.GetMsgNumRequest.Parser, new[]{ "Num1", "Num2" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::GRPCNetCoreDemo.Protocol.GetMsgSumReply), global::GRPCNetCoreDemo.Protocol.GetMsgSumReply.Parser, new[]{ "Sum" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class GetMsgNumRequest : pb::IMessage<GetMsgNumRequest> {
    private static readonly pb::MessageParser<GetMsgNumRequest> _parser = new pb::MessageParser<GetMsgNumRequest>(() => new GetMsgNumRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetMsgNumRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GRPCNetCoreDemo.Protocol.MsgReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetMsgNumRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetMsgNumRequest(GetMsgNumRequest other) : this() {
      num1_ = other.num1_;
      num2_ = other.num2_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetMsgNumRequest Clone() {
      return new GetMsgNumRequest(this);
    }

    /// <summary>Field number for the "Num1" field.</summary>
    public const int Num1FieldNumber = 1;
    private int num1_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Num1 {
      get { return num1_; }
      set {
        num1_ = value;
      }
    }

    /// <summary>Field number for the "Num2" field.</summary>
    public const int Num2FieldNumber = 2;
    private int num2_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Num2 {
      get { return num2_; }
      set {
        num2_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetMsgNumRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetMsgNumRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Num1 != other.Num1) return false;
      if (Num2 != other.Num2) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Num1 != 0) hash ^= Num1.GetHashCode();
      if (Num2 != 0) hash ^= Num2.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Num1 != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Num1);
      }
      if (Num2 != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Num2);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Num1 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Num1);
      }
      if (Num2 != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Num2);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetMsgNumRequest other) {
      if (other == null) {
        return;
      }
      if (other.Num1 != 0) {
        Num1 = other.Num1;
      }
      if (other.Num2 != 0) {
        Num2 = other.Num2;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Num1 = input.ReadInt32();
            break;
          }
          case 16: {
            Num2 = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public sealed partial class GetMsgSumReply : pb::IMessage<GetMsgSumReply> {
    private static readonly pb::MessageParser<GetMsgSumReply> _parser = new pb::MessageParser<GetMsgSumReply>(() => new GetMsgSumReply());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<GetMsgSumReply> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GRPCNetCoreDemo.Protocol.MsgReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetMsgSumReply() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetMsgSumReply(GetMsgSumReply other) : this() {
      sum_ = other.sum_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public GetMsgSumReply Clone() {
      return new GetMsgSumReply(this);
    }

    /// <summary>Field number for the "Sum" field.</summary>
    public const int SumFieldNumber = 1;
    private int sum_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Sum {
      get { return sum_; }
      set {
        sum_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as GetMsgSumReply);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(GetMsgSumReply other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Sum != other.Sum) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Sum != 0) hash ^= Sum.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Sum != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Sum);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Sum != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Sum);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(GetMsgSumReply other) {
      if (other == null) {
        return;
      }
      if (other.Sum != 0) {
        Sum = other.Sum;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Sum = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
