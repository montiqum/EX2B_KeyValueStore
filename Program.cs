using System;
using System.Collections.Generic;

namespace EX2B_KeyValueStore
{
    public struct KeyValue
    {
        public readonly string key;
        public readonly object value;
        public KeyValue(string key, object value)
        {
            this.key = key;
            this.value = value;
        }
    }
    class MyDictionary
    {
        private KeyValue[] myarray = new KeyValue[10];
        private int myint = 0;

        public object this[string keyIndex]
        {
            get 
            {
                for (int i = 0; i < myarray.Length; i++)  // search the array for indexer
                {
                    if(myarray[i].key == keyIndex)  // if the key matches the indexer
                    {
                        return myarray[i].value; // return the value associated
                    }
                }                
                throw new KeyNotFoundException(keyIndex); // if key is not found
            }
            set 
            {
                for (int i = 0; i < myarray.Length; i++)  // search the array 
                {
                    if(myarray[i].key != null)  // if the key is not null then there's a struct in that position
                    {
                        myint++; //count number of structs already existing
                    }
                    if (myarray[i].key == keyIndex)  // if the key matches the indexer
                    {
                        myarray[i] = new KeyValue(keyIndex, value); // rewrite the KeyValue struct to that position
                        return;
                    }                    
                }
                //if indexer is not found
                for (int i = 0; i < myarray.Length; i++)  // search the array 
                {
                    if (myarray[i].key == null && myint != myarray.Length) // if the position is empty and the array is not full
                    {
                        myarray[i] = new KeyValue(keyIndex, value);  // add the KeyValue struct to that position
                        myint++; // increment the counter for a new value
                        return;
                    }
                    if (myint == myarray.Length) // if array is full
                    {
                        Console.WriteLine("Array is full!");
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var d = new MyDictionary();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
        }
    }
}
