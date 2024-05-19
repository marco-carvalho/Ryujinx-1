using Ryujinx.Graphics.GAL;
using SharpMetal.Metal;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace Ryujinx.Graphics.Metal
{
    // TODO: use this (unused right now)
    public struct DirtyFlags
    {
        public bool Pipeline = false;
        public bool DepthStencil = false;

        public DirtyFlags() { }

        public void MarkAll() {
            Pipeline = true;
            DepthStencil = true;
        }
    }

    [SupportedOSPlatform("macos")]
    public struct EncoderState
    {
        public const int MaxColorAttachments = 8;

        public MTLFunction? VertexFunction = null;
        public MTLFunction? FragmentFunction = null;

        public Dictionary<ulong, MTLTexture> FragmentTextures = new();
        public Dictionary<ulong, MTLSamplerState> FragmentSamplers = new();

        public Dictionary<ulong, MTLTexture> VertexTextures = new();
        public Dictionary<ulong, MTLSamplerState> VertexSamplers = new();

        public List<BufferInfo> UniformBuffers = [];
        public List<BufferInfo> StorageBuffers = [];

        public MTLBuffer IndexBuffer = default;
        public MTLIndexType IndexType = MTLIndexType.UInt16;
        public ulong IndexBufferOffset = 0;

        public MTLDepthStencilState? DepthStencilState = null;

        public MTLDepthClipMode DepthClipMode = MTLDepthClipMode.Clip;
        public MTLCompareFunction DepthCompareFunction = MTLCompareFunction.Always;
        public bool DepthWriteEnabled = false;

        public MTLStencilDescriptor BackFaceStencil = new();
        public MTLStencilDescriptor FrontFaceStencil = new();
        public bool StencilTestEnabled = false;

        public PrimitiveTopology Topology = PrimitiveTopology.Triangles;
        public MTLCullMode CullMode = MTLCullMode.None;
        public MTLWinding Winding = MTLWinding.Clockwise;

        public MTLViewport[] Viewports = [];
        public MTLScissorRect[] Scissors = [];

        // Changes to attachments take recreation!
        public MTLTexture DepthStencil = default;
        public MTLTexture[] RenderTargets = new MTLTexture[MaxColorAttachments];
        public Dictionary<int, BlendDescriptor> BlendDescriptors = new();
        public ColorF BlendColor = new();

        public VertexBufferDescriptor[] VertexBuffers = [];
        public VertexAttribDescriptor[] VertexAttribs = [];

        // Dirty flags
        public DirtyFlags Dirty = new();

        public EncoderState() { }
    }
}