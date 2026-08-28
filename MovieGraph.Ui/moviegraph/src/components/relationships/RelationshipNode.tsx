import {
  Handle,
  Position,
  type NodeProps,
} from "@xyflow/react";

interface RelationshipNodeData {
  label: string;
  type: string;
}

const nodeConfig: Record<
  string,
  {
    icon: string;
    label: string;
  }
> = {
  Movie: {
    icon: "🎬",
    label: "Movie",
  },
  Genre: {
    icon: "🎞️",
    label: "Genre",
  },
  Actor: {
    icon: "🎭",
    label: "Actor",
  },
  Director: {
    icon: "🎥",
    label: "Director",
  },
  User: {
    icon: "👤",
    label: "User",
  },
};

const RelationshipNode = ({
  data,
}: NodeProps) => {
  const nodeData = data as unknown as RelationshipNodeData;

  const config =
    nodeConfig[nodeData.type] ?? {
      icon: "🔗",
      label: nodeData.type,
    };

  return (
    <div className="relative min-w-40 rounded-xl border border-gray-700 bg-gray-900 px-4 py-3 text-center shadow-lg">
      {/* Target Handle */}
      <Handle
        type="target"
        position={Position.Top}
        className="h-2.5! w-2.5! border-2! border-gray-900! bg-gray-400!"
      />

      {/* Node Content */}
      <div className="text-2xl">
        {config.icon}
      </div>

      <div className="mt-1 truncate font-semibold text-white">
        {nodeData.label}
      </div>

      <div className="mt-1 text-xs uppercase tracking-wider text-gray-500">
        {config.label}
      </div>

      {/* Source Handle */}
      <Handle
        type="source"
        position={Position.Bottom}
        className="h-2.5! w-2.5! border-2! border-gray-900! bg-gray-400!"
      />
    </div>
  );
};

export default RelationshipNode;