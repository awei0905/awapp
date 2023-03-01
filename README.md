# DUMP / RESTORE PostgreSQL Kubernetes :)

## DUMP (備份資料庫數據)

```bash
kubectl exec [pod-name] -- bash -c "pg_dump -U [postgres-user] [database-name]" > database.sql
```
| option        | Description                                       |
| ------------- | ------------------------------------------------- |
| pod-name      | name of the postgres pod                          |
| postgres-user | database user that is able to access the database |
| database-name | name of the database                              |

* **Dump 資料庫數據透過 kubectl：**
```bash
kubectl exec postgres-0 -- bash -c "pg_dump -U postgres postgres" > ./data/> database_new.sql 
```

## RESTORE (恢復資料庫數據)
```bash
cat database.sql | kubectl exec -i [pod-name] -- psql -U [postgres-user] -d [database-name]
```
| option        | Description                                       |
| ------------- | ------------------------------------------------- |
| pod-name      | name of the postgres pod                          |
| postgres-user | database user that is able to access the database |
| database-name | name of the database                              |

* **Restore 資料庫數據透過 kubectl：**
```bash
cat ./data/database.sql | kubectl exec -i postgres-0 -- psql -U postgres -d postgres
```
Reference:
[ricjcosme/dump-restore](https://gist.github.com/ricjcosme/cf576d3d4272cc35de1335a98c547da6)
