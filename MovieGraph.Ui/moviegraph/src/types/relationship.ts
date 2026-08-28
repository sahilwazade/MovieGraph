export interface MovieRelationshipNode {
  id: string;
  label: string;
  type: string;
}

export interface MovieRelationship {
  source: string;
  target: string;
  type: string;
}

export interface MovieRelationshipGraph {
  nodes: MovieRelationshipNode[];
  relationships: MovieRelationship[];
}