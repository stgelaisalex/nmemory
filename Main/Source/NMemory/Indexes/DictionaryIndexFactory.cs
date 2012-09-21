﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NMemory.DataStructures;
using NMemory.Tables;

namespace NMemory.Indexes
{
    public class DictionaryIndexFactory : IndexFactoryBase
    {
        public DictionaryIndexFactory(IKeyInfoFactory keyInfoFactory)
            : base(keyInfoFactory)
        {

        }

        public DictionaryIndexFactory()
        {

        }

        public override IIndex<TEntity, TKey> CreateIndex<TEntity, TKey>(ITable<TEntity> table, IKeyInfo<TEntity, TKey> keyInfo)
        {
            Hashtable<TKey, TEntity> hashTable = new Hashtable<TKey, TEntity>();
            Index<TEntity, TKey> index = new Index<TEntity, TKey>(table, keyInfo, hashTable);

            return index;
        }

        public override IUniqueIndex<TEntity, TUniqueKey> CreateUniqueIndex<TEntity, TUniqueKey>(ITable<TEntity> table, IKeyInfo<TEntity, TUniqueKey> keyInfo)
        {
            UniqueHashtable<TUniqueKey, TEntity> hashTable = new UniqueHashtable<TUniqueKey, TEntity>();
            UniqueIndex<TEntity, TUniqueKey> index = new UniqueIndex<TEntity, TUniqueKey>(table, keyInfo, hashTable);

            return index;
        }
    }
}
