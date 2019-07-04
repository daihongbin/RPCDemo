--启动Consul命令行
consul agent -server -datacenter=grpc-consul -bootstrap -data-dir ./data -ui -node=grpc-consul1 -bind 202.135.136.193 -client=0.0.0.0