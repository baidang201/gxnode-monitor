# gxnode-monitor
公信节点监控器，可监控丢块数量与投票数量。可通过钉钉机器人发送报警信息。同时可以在丢块数量达到指定值后进行主备切换。
## 编译
预先安装.net core 2.2版本。然后使用以下命令进行clone下载代码：
```shell
git clone https://github.com/wjfree/gxnode-monitor.git --recursive
```
使用以下命令进行编译：
```shell
dotnet build -c Release -o ~/gxnode-monitor/bin
```
编译成功后，将源码中的config.json文件复制到bin目录中，按照自己的需要进行修改

```json
{
  "witness_id": "gxcchainclub", //节点账户名称
  "wallet_passwd": "12345678",  //钱包密码（主备切换需要）
  "produce_public_keys": [      //出块的两个密钥（主备切换需要）
    "GXC5xZCCq2QHctJtW8i7mZZxbrnHYQqmPN9cuGEc3KwyeijzipGJg",
    "GXC86wYZCQqU2Z4gyoauTuQuVKHUfkhGZyjZf3bJqKQMTE2NjMHbj"
  ],
  "miss_block_interval": 360,   //监控丢块的时间周期
  "warn_miss_block_count": 2,   //丢块报警的数量
  "switch_miss_block_count": 4, //丢块进行主备切换的数量
  "cli_wallet_path": "/Users/wjfree/cli_wallet",  （主备切换需要）
  "wallet_file_path": "/Users/wjfree/",  （主备切换需要）
  "api_url": "https://testnet.gxchain.org/rpc",
  "wss_url": "wss://testnet.gxchain.org",  

  "enable_node_switch": true, //是否启用主备切换功能
  "dingding_alarm_url": "https://oapi.dingtalk.com/robot/send?access_token=4104f5353e5143c369fb9631454a05fc35ff9037a9b5218362a6601975acf6ce",

  "enbable_vote_monitor": true,//是否启用投票监控
  "votes_alarm_count": 10000
}
```

