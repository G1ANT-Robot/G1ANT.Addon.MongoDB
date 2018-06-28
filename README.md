# G1ANT.Addon.MongoDB

**MongoDB Addon for G1ANT.Robot** 

Simple addon for fetching data from MonogDB (NoSQL database)

**Simple usage** 

```
mongodb.init connectionstring ‴mongodb://127.0.0.1:27017‴ databasename ‴db_name‴
mongodb.find collection ‴collection_name‴  filter ‴{name : John}‴ sort ‴{_id:-1}‴ skip 5 limit 10 result ♥json
dialog message ♥json

```

Results are returned as JSON formatted into string
