/*
// Define the hash table data structure
class HashTable :
    // Constructor to initialize the hash table with a given size
    function __init__(size):
        this.size = size
        this.table = new Array[size] // Array of buckets to store key-value pairs

    // Define a hash function to compute the primary hash
    function hash(key):
        // ... Hash function implementation ...
        // Returns an index in the range [0, size-1]

    // Define a secondary hash function to compute the secondary hash for double hashing
    function secondaryHash(key):
        // ... Secondary hash function implementation ...
        // Returns an integer that is relatively prime to size





    // Define a function to insert a key-value pair into the hash table
    function insert(key, value):
        index = hash(key) // Compute the primary hash

        if table[index] is empty: // If the bucket is empty
            table[index] = (key, value) // Store the key-value pair in the bucket
        else: // If the bucket is not empty, resolve collision using double hashing
            step = secondaryHash(key) // Compute the secondary hash step
            i = 1 // Initialize the step counter

            // Loop until an empty bucket is found
            while table[(index + i * step) % size] is not empty:
                i = i + 1 // Move to the next step
            end while

            // Store the key-value pair in the empty bucket
            table[(index + i * step) % size] = (key, value)




    // Define a function to retrieve the value associated with a given key
    function retrieve(key):
        index = hash(key) // Compute the primary hash

        if table[index] is not empty:
            if table[index].key is equal to key: // If the key matches
    return table[index].value // Return the corresponding value
            else: // If the key doesn't match, use double hashing to find the correct bucket
                step = secondaryHash(key) // Compute the secondary hash step
                i = 1 // Initialize the step counter

                // Loop until the key is found or an empty bucket is encountered
                while table[(index + i * step) % size] is not empty:
                    if table[(index + i * step) % size].key is equal to key: // If the key matches
    return table[(index + i * step) % size].value // Return the corresponding value
                    i = i + 1 // Move to the next step
                end while
        }

        return null // Key not found
    end function



    // Define a function to remove a key-value pair from the hash table
    function remove(key):
        index = hash(key) // Compute the primary hash

        if table[index] is not empty:
            if table[index].key is equal to key: // If the key matches
    table[index] = null // Remove the key-value pair from the bucket
                return // Return successfully
            else: // If the key doesn't match, use double hashing to find the correct bucket
                step = secondaryHash(key) // Compute the secondary hash step
                i = 1 // Initialize the step counter

                // Loop until the key is found or an empty bucket is encountered
                while table[(index + i * step) % size] is not empty:
                    if table[(index + i * step) % size].key is equal to key: // If the key matches
    table[(index + i * step) % size] = null // Remove the
                    // key-value pair from the bucket
                    return // Return successfully
                    i = i + 1 // Move to the next step
                end while
        }

        return // Key not found
    end function
*/

using System.Drawing;
using System;
using System.Reflection;

class HashTable
{

    private KeyValuePair<object, object>[] MyHashTable;
    private int size;

    static int[] NumberArray;
    static string[] StringArray;

    public HashTable(int size)
    {
        this.size = size;
        MyHashTable = new KeyValuePair<object, object>[size]; // Initialize the hash table with specified size
    }

    static void Main()
    {



    }

    int Hash(object Key)
    {
        int hashValue = 0; // Initialize the hash value to 0

        if (Key == null)
        {
            return hashValue;
        }

        string KeyString = Key.ToString(); // Convert the input key to a string

        // Loop through each character in the key
        for (int i = 0; i < KeyString.Length; i++)
        {
            char tempKey = KeyString[i]; // Get the current character
            hashValue = (hashValue * 31) + tempKey.GetHashCode(); // Update the hash value using a constant multiplier (31) and the hash code of the character
        }

        return hashValue; // Return the final hash value
    }

    int SecondHash(object Key)
    {
        int hashValue = 0;
        int Prime = 31; // Prime Value used for hashing
        char TempKey;

        if (Key == null)
        {
            return hashValue;
        }

        string keyString = Key.ToString();

        for (int i = 0; i < keyString.Length - 1; i++)
        {
            TempKey = keyString[i]; // Get the current character
            hashValue = (hashValue * Prime + TempKey);
        }
        return hashValue; // Return the final hash value
    }

    void Insert(string Key, int Value)
    {
        int index = Hash(Key) % size;

        if (MyHashTable[index].Equals(default(KeyValuePair<object, object>))) // If the bucket is empty
        {
            MyHashTable[index] = new KeyValuePair<object, object>(Key, Value); // Store the key-value pair in the bucket
        }
        else // If the bucket is not empty, resolve collision using double hashing
        {
            int Step = SecondHash(Key); // Compute the secondary hash step
            int i = 1; // Initialize the step counter

            // Loop until an empty bucket is found
            while (!MyHashTable[(index + i * Step) % size].Equals(default(KeyValuePair<object, object>)))
            {
                i = i + 1; // Move to the next step
            }

            // Store the key-value pair in the empty bucket
            MyHashTable[(index + i * Step) % size] = new KeyValuePair<object, object>(Key, Value);
        }
    }

    public object GetKey(object Key)
    {
        int Index = Hash(Key);

        if (!MyHashTable[Index].Equals(default(KeyValuePair<object, object>)))
        {
            if (MyHashTable[Index].Key.Equals(Key))
            {
                return MyHashTable[Index].Value;
            }
            else
            {
                int Step = SecondHash(Key);
                int i = 1;

                while (!MyHashTable[(Index + i * Step) % size].Equals(default(KeyValuePair<object, object>)))
                {
                    if (MyHashTable[(Index + i * Step) % size].Key.Equals(Key))
                    {
                        return MyHashTable[(Index + i * Step) % size].Value;
                    }
                    i++;
                }
                return null;
            }
        }
        return null;
    }
}