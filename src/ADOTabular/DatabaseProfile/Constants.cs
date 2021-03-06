﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOTabular.DatabaseProfile.Queries
{
    public class Constants
    {
        public const string Tables = @"SELECT 
    DIMENSION_NAME AS TABLE_NAME, 
    TABLE_ID AS TABLE_ID,
    ROWS_COUNT AS ROWS_IN_TABLE,
    RIVIOLATION_COUNT
FROM  $SYSTEM.DISCOVER_STORAGE_TABLES
WHERE RIGHT ( LEFT ( TABLE_ID, 2 ), 1 ) <> '$'
ORDER BY DIMENSION_NAME";
        public const string Columns = @"SELECT
    DIMENSION_NAME AS TABLE_NAME, 
    COLUMN_ID AS COLUMN_ID, 
    ATTRIBUTE_NAME AS COLUMN_NAME, 
    DATATYPE ,
    DICTIONARY_SIZE AS DICTIONARY_SIZE_BYTES
FROM  $SYSTEM.DISCOVER_STORAGE_TABLE_COLUMNS
WHERE COLUMN_TYPE = 'BASIC_DATA'";
        public const string ColumnCardinality = @"SELECT
    DIMENSION_NAME AS TABLE_NAME, 
    TABLE_ID AS COLUMN_HIERARCHY_ID,
    ROWS_COUNT - 3 AS COLUMN_CARDINALITY
FROM $SYSTEM.DISCOVER_STORAGE_TABLES
WHERE LEFT ( TABLE_ID, 2 ) = 'H$'
ORDER BY TABLE_ID";
        public const string ColumnSegments = @"SELECT 
    DIMENSION_NAME AS TABLE_NAME, 
    TABLE_ID,
    PARTITION_NAME, 
    COLUMN_ID , 
    SEGMENT_NUMBER, 
    TABLE_PARTITION_NUMBER, 
    RECORDS_COUNT AS SEGMENT_ROWS,
    USED_SIZE,
    COMPRESSION_TYPE,
    BITS_COUNT,
    BOOKMARK_BITS_COUNT,
    VERTIPAQ_STATE
FROM $SYSTEM.DISCOVER_STORAGE_TABLE_COLUMN_SEGMENTS";
//WHERE RIGHT ( LEFT ( TABLE_ID, 2 ), 1 ) <> '$'";
        
        public const string ColumnHierarchies = @"SELECT 
    DIMENSION_NAME AS TABLE_NAME, 
    COLUMN_ID AS STRUCTURE_NAME,
    SEGMENT_NUMBER, 
    TABLE_PARTITION_NUMBER, 
    USED_SIZE,
    TABLE_ID AS COLUMN_HIERARCHY_ID
FROM $SYSTEM.DISCOVER_STORAGE_TABLE_COLUMN_SEGMENTS
WHERE LEFT ( TABLE_ID, 2 ) = 'H$'";
        public const string UserHierarchies = @"SELECT 
    DIMENSION_NAME AS TABLE_NAME, 
    COLUMN_ID AS STRUCTURE_NAME,
    USED_SIZE,
    TABLE_ID AS HIERARCHY_ID
FROM $SYSTEM.DISCOVER_STORAGE_TABLE_COLUMN_SEGMENTS
WHERE LEFT ( TABLE_ID, 2 ) = 'U$'";
        public const string Relationships = @"SELECT 
    DIMENSION_NAME AS TABLE_NAME, 
    USED_SIZE,
    TABLE_ID AS RELATIONSHIP_ID
FROM $SYSTEM.DISCOVER_STORAGE_TABLE_COLUMN_SEGMENTS
WHERE LEFT ( TABLE_ID, 2 ) = 'R$'";
        public const string TableNames = @"SELECT 
    RIGHT ( TABLE_SCHEMA, LEN ( TABLE_SCHEMA ) - 1 ) AS TABLE_NAME, 
    TABLE_NAME AS TABLE_ID
FROM $SYSTEM.DBSCHEMA_TABLES
WHERE TABLE_TYPE = 'SYSTEM TABLE'
  AND LEFT(TABLE_SCHEMA,1)='$'";
    


    }
}
