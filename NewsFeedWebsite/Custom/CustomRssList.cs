

namespace NewsFeedWebsite.Custom
{
    public class CustomRssList<T> : ICustomList<T>
    {
        private T[] _itemArray;
        public CustomRssList()
        {
            // max capacity
            _itemArray = new T[25];
        }

        public void Add(T item)
        {
            for (int i = 0; i < _itemArray.Length; i++)
            {
                //Check if a slot/index is empty 
                if(_itemArray[i] == null)
                {
                    //Add Item to the Empty Slot/Index
                    _itemArray[i] = item;
                    break;
                }
            }

        }

        public void Remove(T item)
        {
        }

        public T[] Tolist()
        {
            return _itemArray;
        }
    }
}
