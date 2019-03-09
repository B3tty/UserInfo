CREATE KEYSPACE IF NOT EXISTS mk 
   WITH REPLICATION = { 
      'class' : 'SimpleStrategy', 'replication_factor' : 1 };
      
USE mk;

CREATE TABLE IF NOT EXISTS page_info_by_user (
   user_id text,
   time_stamp timestamp,
   page_name text,
   PRIMARY KEY (user_id, time_stamp)
);