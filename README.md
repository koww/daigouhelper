# daigouhelper
An iOS app written in C# with Xamarin iOS and VS for Mac.    
专门为去各大商场奥莱代购时使用，可计算折扣后的价格（税前/税后，$/￥）和加上运费之后的价格（$/￥）。

Change Log:
v1.2
- 更新汇率计算方式为手动设置，暂时抛弃实时汇率而改用Stepper[6.0, 7.0, delta = 0.1]来计算

v1.1
- 添加了默认／实时汇率切换，默认汇率依然是7，实时汇率来自[Fixer.io](http://fixer.io/)的API

v1.0    
- 折扣按减法计算，如60% off请填写60    
- 最多3次折扣（店内，店内additional，非店内additional），使用乘法计算。线性相加请口算
- 目前税率使用麻省消费税6.25%    
- 目前使用固定汇率7    
- 目前使用固定运费计算列表（重量2-7磅，单价$5-7）
