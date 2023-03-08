# DUMP / RESTORE PostgreSQL Kubernetes

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




# Shopping Cart

# Demo link
https://www.example.com
# Table of Content

# Screenshots

# About APP
<br />

* 用來練習的 Side project，簡易的購物網中。\
  使用容器化開發，使應用程式具備高彈性、高擴展性、簡化部署，而分使用虛擬機器的架構。
* 本專案包含購物網站的基本要素，例如會員、購物車、訂單、商品列表和報表功能。\
<br />

## Environment:
* ARM64 macOS (Apple M1 Pro)
* Storage: at least 20GB
## Requirements:
1. Docker
2. Minikube
3. Kubernetes (kubectl)
## Technologies:
1. ASP.NET Core Web API
2. Vue.js 3.x
2. MongoDB
3. Redis
4. PostgreSQL

<br/>

# How to run this project:
## 1. Docker for Mac Apple Chip (ARM64)
> 下載安裝 Mac Apple Chip ARM64 版本的 Docker Desktop 安裝 darwin/arm64 架構的 Docker。\
> [Download and install Docker from offical website](https://www.docker.com/)


<br />

## 2. Minikube for ARM64 macOS 
> 下載安裝 Minikube，這邊選擇安裝 ARM64 的版本。 (macOS, ARM64, Stable, binary)\
> [Install the latest minikube stable release on ARM64 macOS using binary download](https://minikube.sigs.k8s.io/docs/start/)
> <br />
> 安裝指令：
>> ```bash
>> # 下載檔案，存放當前目錄
>> curl -LO https://storage.googleapis.com/minikube/releases/latest/minikube-darwin-arm64
>> 
>> # 執行安裝
>> sudo install minikube-darwin-arm64 /usr/local/bin/minikube
>> ```

<br />

## 3. Kubernetes for ARM64 macOS
> 按照網頁上的教學進行安裝。\
> [Install and Set Up kubectl on macOS](https://kubernetes.io/docs/tasks/tools/install-kubectl-macos/)\
> 安裝指令：
> ```bash
> # 下載檔案，存放當前目錄
> curl -LO "https://dl.k8s.io/release/$(curl -L -s https://dl.k8s.io/release/stable.txt)\
> /bin/darwin/arm64/kubectl"
>
> # 執行安裝
> sudo install minikube-darwin-arm64 /usr/local/bin/minikube
> ```
> 

## 4. 部署專案至 Minikube
>
> ```bash
> # 啟動 minikube
> $ minikube start
>
> 😄  minikube v1.29.0 on Darwin 13.2.1 (arm64)
> ✨  Automatically selected the docker driver. Other choices: hyperkit, parallels, virtualbox, ssh
> 📌  Using Docker Desktop driver with root privileges
> 👍  Starting control plane node minikube in cluster minikube
> 🚜  Pulling base image ...
> 🔥  Creating docker container (CPUs=2, Memory=4000MB) ...
> 🐳  Preparing Kubernetes v1.26.1 on Docker 20.10.23 ...
>     ▪ Generating certificates and keys ...
>     ▪ Booting up control plane ...
>     ▪ Configuring RBAC rules ...
> 🔗  Configuring bridge CNI (Container Networking Interface) ...
>     ▪ Using image gcr.io/k8s-minikube/storage-provisioner:v5
> 🔎  Verifying Kubernetes components...
> 🌟  Enabled addons: storage-provisioner, default-storageclass
> 🏄  Done! kubectl is now configured to use "minikube" cluster and "default" namespace by default
> 
> # 透過 k8s 部署應用程式到 minikube
> $ kubectl apply -f deploy.yaml
> 
> 
> # 建立一個路由連到 LoadBalancer (ingress)，開著不要關閉。
> $ minikube tunnel
> 
> ✅  Tunnel successfully started
> 📌  NOTE: Please do not close this terminal as this process must stay alive for the tunnel to be accessible ...
> # 如何關閉tunnel? Ctrl + C !
> ```
>

# License
See [LICENSE.md](/LICENSE.md)