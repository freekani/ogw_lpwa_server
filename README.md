# ogw_lpwa_server
### ホスト名
https://ogwlpwa.azurewebsites.net
### 使い方
[https://ogwlpwa.azurewebsites.net/api/alert](https://ogwlpwa.azurewebsites.net/api/alert) にアクセスすれば現在入っているデータを見ることができます。  
そのほかは[こっち](https://github.com/freekani/ogw_lpwa)見てください。
### 注意
鯖代の関係でDBもストレージも無いので1分程度アクセスがないとデータが揮発します。
データが空っぽになってしまったら、
https://ogwlpwa.azurewebsites.net/api/alert/addtest
にアクセスしてデータを追加しても大丈夫です
