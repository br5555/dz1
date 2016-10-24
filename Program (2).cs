using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz1_zadatak2
{
    public interface IGenericList<X> : IEnumerable<X>    {
        ///<summary>
        ///Adds an item to the collection
        /// </summary>
        void Add(X item);

        ///<summary>
        ///Removes the first occurrence of an item from the collection
        ///If the item was not found, method does nothing.
        /// </summary>
        bool Remove(X item);

        ///<summary>
        ///Removes the item at the given index in the collection
        /// </summary>
        bool RemoveAt(int index);

        ///<summary>
        ///Returns the item at the given index in the collection
        /// </summary>
        X GetElement(int index);

        ///<summary>
        ///Returns the index of the item in the collection.
        ///If item is not found in the collection, method returns -1
        /// </summary>
        int IndexOf(X item);

        ///<summary>
        ///Readonly property. Gets the number of items contained in the collection.
        /// </summary>
        int Count { get; }

        ///<summary>
        ///Removes all items from the collection.
        /// </summary>
        void Clear();

        ///<summary>
        ///Determines whether the collection contains a specific value.
        /// </summary>
        bool Contains(X item);

    }

    class Program
    {
        public class GenericListEnumerator<X> : IEnumerator<X>
        {
            private GenericList<X> _univerzalanaLista;
            private int currentIndex ;

            public GenericListEnumerator(GenericList<X> lista)
            {
                _univerzalanaLista = lista;
                currentIndex = -1;
            }

            public X Current
            {
                get
                {
                    try
                    {
                        return _univerzalanaLista.GetElement(currentIndex);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                throw new NotImplementedException(); ;
            }

            public bool MoveNext()
            {
                
                currentIndex++;
                return (currentIndex < _univerzalanaLista.Count);
            }

            public void Reset()
            {
                currentIndex=-1;
            }
        }
        public class GenericList<X> : IGenericList<X>
        {
            private List<X> _univerzalnaLista;
            
            private int SizeOfList;
            
            public GenericList(int a)
            {
                _univerzalnaLista = new List<X>(a);
                SizeOfList = a;
                
            }

            public int Count
            {
                get
                {
                    return _univerzalnaLista.Count();
                }
            }

            public void Add(X item)
            {
                if((_univerzalnaLista.Count() - 1) >= SizeOfList)
                {
                    Console.WriteLine("Lista je premalena");
                }
                else
                {
                    
                    _univerzalnaLista.Add(item);
                }
                   
            }

            public void Clear()
            {
             _univerzalnaLista.Clear();
            }

            public bool Contains(X item)
            {
               return _univerzalnaLista.Contains(item);
            }

            public X GetElement(int index)
            {

                return _univerzalnaLista[index];
            }

            public int IndexOf(X item)
            {   
               return _univerzalnaLista.FindIndex(a =>  a.Equals(item));
            }

            public bool Remove(X item)
            {   
                bool postoji = _univerzalnaLista.Contains(item); 
                _univerzalnaLista.Remove(item);
                
                return postoji;
            }

            public bool RemoveAt(int index)
            {
                if( (_univerzalnaLista.Count() -1) < index || index < 0)
                {
                    return false;
                }
                _univerzalnaLista.RemoveAt(index);
                
                return true;
            }
            public IEnumerator<X> GetEnumerator()
            {
                return new GenericListEnumerator<X>(this);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        static void Main(string[] args)
        {

            GenericList<int> proba = new GenericList<int>(8);
            proba.Add(8);
            proba.Add(16);
            proba.Add(99);
            Console.WriteLine(proba.IndexOf(99));
            Console.Read();

        }
    }
}
