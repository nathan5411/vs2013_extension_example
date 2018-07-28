// Guids.cs
// MUST match guids.h
using System;

namespace Company.VSPackage1
{
    static class GuidList
    {
        public const string guidVSPackage1PkgString = "f2f4ad64-ff3e-4592-a4e2-e16e193714f5";
        public const string guidVSPackage1CmdSetString = "cf598a74-3a7c-4db8-82a8-0467babe7dca";
        public const string guidToolWindowPersistanceString = "a4288d84-e4be-4f0e-a941-d478417db800";

        public static readonly Guid guidVSPackage1CmdSet = new Guid(guidVSPackage1CmdSetString);
    };
}