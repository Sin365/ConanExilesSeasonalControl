# ConanExilesSeasonalControl

流放者柯南服务器
原创的季节控制系统


可实现动态控制服务器内季节，并在换季的时候提示。
不同的季节有不同的特点，增加游戏趣味
温暖繁殖期 动物大幅繁殖，但比较凶猛，适合捕捉
炎热丰饶期  矿物产出高，但容易口渴，速度下降 适合采集
冬季  建造速度上升，但不适合出门 等等


实现方式：
我发现柯南服务端管理控制台就是基于RCON.

程序使用Minecraft RCON连接Conan服务器即可

服务端开启Rcon并指定密码 命令：

    ConanSandboxServer.exe -log -RconEnabled=1 -RconPassword=yourpassword -RconPort=25575
