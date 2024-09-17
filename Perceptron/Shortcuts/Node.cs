 namespace Shortcuts
{

    public class Node<T>
    {
        private List<Node<T>> neighbours = new List<Node<T>>();
        T value;
        Node<T> parent;

        public T Value { get => value; set => this.value = value; }
        public int Neighbour_Count { get => neighbours.Count; }
        public Node<T> Parent { get => parent; set => parent = value; }
        public bool Visted = false;

        Node(T Value)
        {
            value = Value;
        }

        Node (T Value, List<Node<T>> neighbours)
        {
            value = Value;
            this.neighbours = neighbours;
        }

        public Node<T> Add_neighbour(Node<T> new_node)
        {
            neighbours.Add(new_node);
            return new_node;
        }

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

        public void Remove_neighbour(Node<T> node)
        {
            neighbours.Remove(node);
        }

        public void Clear_neighbours()
        {
            neighbours.Clear();
        }

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

