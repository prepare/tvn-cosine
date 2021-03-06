﻿using Tvn.Cosine.Data;

namespace Tvn.Cosine.Text.Nlp
{
    public class NamedEntity : IName, IDescription
    {
        public NamedEntity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Description { get; }
        public string Name { get; } 
    }
}
