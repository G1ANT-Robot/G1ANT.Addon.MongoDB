# G1ANT.Addon.MongoDB

**MongoDB Addon for G1ANT.Robot** 

Simple addon for fetching data from MonogDB (NoSQL database)

**Simple usage** 

```
mongodb.init connectionstring ‴mongodb://user:pass@127.0.0.1:27017‴ databasename ‴db_name‴
mongodb.find collection ‴collection_name‴  filter ‴{name : John}‴ sort ‴{_id:-1}‴ skip 5 limit 10 result ♥json
dialog message ♥json

```

Results are returned as JSON formatted into string

See more:<br/>
<ul>
<li><a href="https://mongodb.github.io/mongo-java-driver/3.5/javadoc/com/mongodb/ConnectionString.html" target="_blank">about Mongo connection string</a>
<li><a href='https://www.tutorialspoint.com/mongodb/mongodb_query_document.htm' target="_blank">format query into collection </a>
<li><a href='https://www.tutorialspoint.com/mongodb/mongodb_sort_record.htm' target="_blank">sorting in MongoDB</a>
<li><a href='https://www.tutorialspoint.com/mongodb/mongodb_limit_record.htm' target="_blank">limiting and skiping records</a>
</ul>
