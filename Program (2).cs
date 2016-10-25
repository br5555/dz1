using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz1_zadatak1
{
    public interface IIntegerList
    {
        ///<summary>
        ///Adds an item to the collection
        /// </summary>
        void Add(int item);

        ///<summary>
        ///Removes the first occurrence of an item from the collection.
        ///If the item was not found, method does nothing
        /// </summary>
        bool Remove(int item);

        ///<summary>
        ///Removes the item at the given index in the collection
        /// </summary>
        bool RemoveAt(int index);

        ///<summary>
        ///Returns the item at the given index in the collection.
        /// </summary>
        int GetElement(int index);

        ///<summary>
        ///Returns the index of the item in the collection.
        ///If item is not found in the collection, method returns -1
        /// </summary>
        int IndexOf(int item);

        ///<summary>
        ///Readonly property.Gets the number of items contained in the collection.
        /// </summary>
        int Count { get; }

        ///<summary>
        ///Removes all items from the collection
        /// </summary>
        void Clear();

        ///<summary>
        ///determines whether the collection contains a specific value.
        /// </summary>
        bool Contains(int item);


    }


    class Program
    {
        public class IntegerList : IIntegerList
        {
            private int[] _internalStorage;
            private int currentIndex;
            private int sizeList;

            public int Count
            {
                get
                {
                   return _internalStorage.Count();
                }
            }

            public IntegerList(int a)
            {
                _internalStorage = new int[a];
                currentIndex = -1;
                sizeList = a;
            }

            public void Add(int item)
            {
                if(currentIndex < sizeList)
                {
                    _internalStorage[++currentIndex] = item;


                }
                else
                {
                    int[] privremenalista = new int[2*sizeList];
                    Array.Copy(_internalStorage, privremenalista, sizeList);
                    _internalStorage =new int[2 * sizeList];
                    Array.Copy(privremenalista, _internalStorage, sizeList);
                    _internalStorage[++currentIndex] = item;
                }
            }

            public bool Remove(int item)
            {

               _internalStorage= _internalStorage.Where(c => c != item).ToArray();
                currentIndex--;
                return Array.Exists(_internalStorage, a => a == item);
            }

            public bool RemoveAt(int index)
            {
                if(index > currentIndex || index < 0)
                {
                    return false;
                }
                int itemToRemove = _internalStorage[index];
                
                _internalStorage = _internalStorage.Where(c => c != itemToRemove).ToArray();
                currentIndex--;
                return true;
            }

            public int GetElement(int index)
            {   if (index > currentIndex || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return _internalStorage[index];
            }

            public int IndexOf(int item)
            {
                return   Array.FindIndex(_internalStorage, n => n == item);
            }

            public void Clear()
            {
                Array.Clear(_internalStorage, 0, _internalStorage.Count());
            }

            public bool Contains(int item)
            {
               return Array.Exists(_internalStorage, c => c == item);
            }
        }


        static void Main(string[] args)
        {
            IntegerList proba = new IntegerList(8);
            proba.Add(8);
            proba.Add(1);
            proba.Add(11);
            proba.Add(13);
            proba.Add(3);
            proba.Add(99);
            Console.WriteLine(proba.Count);
            for(int i = 0; i < proba.Count; i++)
            {
                Console.WriteLine(proba.GetElement(i));
            }
            Console.WriteLine(proba.Contains(13));
            Console.WriteLine(proba.GetElement(2));
            Console.WriteLine(proba.IndexOf(99));
            proba.Remove(1);
            proba.RemoveAt(4);
            proba.Add(66);
            for (int i = 0; i < proba.Count; i++)
            {
                Console.WriteLine(proba.GetElement(i));
            }
            Console.Read();
       






        }
    }
}
