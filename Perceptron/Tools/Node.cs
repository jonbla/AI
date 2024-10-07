namespace Tools
{

    /// <summary>
    /// Basic Multiuse Node Class
    /// </summary>
    /// <typeparam name="T">Set Value Type</typeparam>
    public class Node<T>
    {
        /// <summary>
        /// Basic connections on this node to other nodes
        /// </summary>
        private List<Node<T>> neighbours = new List<Node<T>>();

        /// <summary>
        /// Value of this node
        /// </summary>
        T value;

        /// <summary>
        /// Parent Node
        /// </summary>
        Node<T> parent;

        /// <summary>
        /// Value of this node
        /// </summary>
        public T Value { get => value; set => this.value = value; }

        /// <summary>
        /// How many basic connections this node has
        /// </summary>
        public int Neighbour_Count { get => neighbours.Count; }

        /// <summary>
        /// Parent Node
        /// </summary>
        public Node<T> Parent { get => parent; set => parent = value; }

        /// <summary>
        /// Flag used for search algorithms
        /// </summary>
        public bool Visted = false;

        /// <summary>
        /// Basic Multiuse Node Class
        /// </summary>
        /// <param name="Value"></param>
        public Node(T Value)
        {
            value = Value;
        }

        /// <summary>
        /// Basic Multiuse Node Class
        /// </summary>
        /// <param name="Value">Value of this node</param>
        /// <param name="neighbours">Basic connections on this node to other nodes</param>
        public Node (T Value, List<Node<T>> neighbours)
        {
            value = Value;
            this.neighbours = neighbours;
        }

        /// <summary>
        /// Add Basic Connection
        /// </summary>
        /// <param name="new_node">Neighbouring Node</param>
        /// <returns>Node that was added</returns>
        public Node<T> Add_neighbour(Node<T> new_node)
        {
            neighbours.Add(new_node);
            return new_node;
        }

        /// <summary>
        /// Get Neighbour by index
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Neighbour at index i</returns>
        public Node<T>? Get_neighbour(int i = 0)
        {
            if (neighbours.Count <= 0) return null;
            try
            {
                return neighbours[i];

            } catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Delete given node
        /// </summary>
        /// <param name="node">node to remove</param>
        public void Remove_neighbour(Node<T> node)
        {
            neighbours.Remove(node);
        }

        /// <summary>
        /// Delete all basic connections
        /// </summary>
        public void Clear_neighbours()
        {
            neighbours.Clear();
        }

        /// <summary>
        /// Does this node have neighbours
        /// </summary>
        /// <returns>True if number of neighbours is greater than 0</returns>
        public bool Has_neighbours()
        {
            return neighbours.Count > 0 ? true : false;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}

