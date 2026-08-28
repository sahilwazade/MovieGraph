import { useMemo } from "react";
import { useQuery } from "@tanstack/react-query";
import {
  ReactFlow,
  Background,
  type Node,
  type Edge,
} from "@xyflow/react";

import "@xyflow/react/dist/style.css";

import { getMovieRelationships } from "../../services/relationshipService";
import RelationshipNode from "./RelationshipNode";

interface MovieRelationshipGraphProps {
  movieId: string;
}

const nodeTypes = {
  relationship: RelationshipNode,
};

const MovieRelationshipGraph = ({
  movieId,
}: MovieRelationshipGraphProps) => {
  const {
    data,
    isLoading,
    isError,
  } = useQuery({
    queryKey: ["movie-relationships", movieId],
    queryFn: () => getMovieRelationships(movieId),
    enabled: Boolean(movieId),
  });

  const nodes = useMemo<Node[]>(() => {
    if (!data) {
      return [];
    }

    const movieNode = data.nodes.find(
      (node) => node.type === "Movie"
    );

    const otherNodes = data.nodes.filter(
      (node) => node.type !== "Movie"
    );

    const positions = [
      { x: 0, y: -250 },
      { x: 300, y: -100 },
      { x: 300, y: 150 },
      { x: 0, y: 300 },
      { x: -300, y: 150 },
      { x: -300, y: -100 },
      { x: 550, y: 100 },
      { x: -550, y: 100 },
      { x: 0, y: -450 },
    ];

    const result: Node[] = [];

    if (movieNode) {
      result.push({
        id: movieNode.id,
        type: "relationship",
        position: {
          x: 0,
          y: 0,
        },
        data: {
          label: movieNode.label,
          type: movieNode.type,
        },
      });
    }

    otherNodes.forEach((node, index) => {
      result.push({
        id: node.id,
        type: "relationship",
        position: positions[index % positions.length],
        data: {
          label: node.label,
          type: node.type,
        },
      });
    });

    return result;
  }, [data]);

  const edges = useMemo<Edge[]>(() => {
    if (!data) {
      return [];
    }

    return data.relationships.map(
      (relationship, index) => ({
        id: `${relationship.source}-${relationship.target}-${index}`,
        source: relationship.source,
        target: relationship.target,
        type: "smoothstep",
        label: relationship.type,
        animated: true,
        style: {
          strokeWidth: 2,
        },
        labelStyle: {
  fontSize: 10,
  fontWeight: 700,
  fill: "#e5e7eb",
},
labelBgStyle: {
  fill: "#374151",
  fillOpacity: 0.95,
},
labelBgPadding: [6, 3],
labelBgBorderRadius: 5,
      })
    );
  }, [data]);

  if (isLoading) {
    return (
      <div className="flex h-[600px] items-center justify-center rounded-xl border border-gray-800 bg-gray-950 text-gray-400">
        Loading relationships...
      </div>
    );
  }

  if (isError) {
    return (
      <div className="flex h-[600px] items-center justify-center rounded-xl border border-gray-800 bg-gray-950 text-red-400">
        Failed to load relationships.
      </div>
    );
  }

  if (!data || data.nodes.length === 0) {
    return (
      <div className="flex h-[600px] items-center justify-center rounded-xl border border-gray-800 bg-gray-950 text-gray-500">
        No relationships found.
      </div>
    );
  }

  return (
    <div className="h-[600px] w-full overflow-hidden rounded-xl border border-gray-800 bg-gray-950">
      <ReactFlow
        nodes={nodes}
        edges={edges}
        nodeTypes={nodeTypes}
        fitView
        fitViewOptions={{
          padding: 0.25,
        }}
        minZoom={0.4}
        maxZoom={1.5}
      >
        <Background gap={20} size={1} />
        
      </ReactFlow>
    </div>
  );
};

export default MovieRelationshipGraph;