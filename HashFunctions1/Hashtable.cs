using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using HashFunctions1;

namespace HashFunctions1
{
    public class HashTable
    {
        private const int TableSize = 400;
        private Nodo[] table;
        private const string FilePath = "atletas.txt";

        public HashTable()
        {
            table = new Nodo[TableSize];
            LoadFromFile();
        }

        private int HashFunction(string key)
        {
            int hash = 0;
            foreach (char c in key)
            {
                hash += c;
            }
            return hash % TableSize;
        }

        public void AddAtleta(Atleta atleta)
        {
            int index = HashFunction(atleta.Apellido);
            Nodo newNode = new Nodo(atleta);
            if (table[index] == null)
            {
                table[index] = newNode;
            }
            else
            {
                Nodo current = table[index];
                while (current.Siguiente != null)
                {
                    current = current.Siguiente;
                }
                current.Siguiente = newNode;
            }
            SaveToFile();
        }

        public Atleta SearchAtleta(string apellido)
        {
            int index = HashFunction(apellido);
            Nodo current = table[index];
            while (current != null)
            {
                if (current.Atleta.Apellido == apellido)
                {
                    return current.Atleta;
                }
                current = current.Siguiente;
            }
            return null;
        }

        public void UpdateAtleta(Atleta updatedAtleta)
        {
            int index = HashFunction(updatedAtleta.Apellido);
            Nodo current = table[index];
            while (current != null)
            {
                if (current.Atleta.Apellido == updatedAtleta.Apellido)
                {
                    current.Atleta = updatedAtleta;
                    SaveToFile();
                    return;
                }
                current = current.Siguiente;
            }
        }

        public void DeleteAtleta(string apellido)
        {
            int index = HashFunction(apellido);
            Nodo current = table[index];
            Nodo prev = null;
            while (current != null)
            {
                if (current.Atleta.Apellido == apellido)
                {
                    if (prev == null)
                    {
                        table[index] = current.Siguiente;
                    }
                    else
                    {
                        prev.Siguiente = current.Siguiente;
                    }
                    SaveToFile();
                    return;
                }
                prev = current;
                current = current.Siguiente;
            }
        }

        private void LoadFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return;
            }

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var atleta = Atleta.FromString(line);
                AddAtleta(atleta);
            }
        }

        private void SaveToFile()
        {
            List<string> lines = new List<string>();
            foreach (var node in table)
            {
                Nodo current = node;
                while (current != null)
                {
                    lines.Add(current.Atleta.ToString());
                    current = current.Siguiente;
                }
            }
            File.WriteAllLines(FilePath, lines);
        }
    }
}

