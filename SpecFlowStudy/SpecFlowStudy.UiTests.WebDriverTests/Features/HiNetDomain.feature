Feature: HiNetDomain
	In order to 購買網域
	As a 潛在消費者
	I want to 知道我想要購買的網域有沒有人使用並購買

@basePage
Scenario: 首頁是Domain HiNet
	Given I navigated to /
	Then The title should be HiNet 域名註冊

@checkDomain
Scenario: 網域已被使用
	Given I navigated to /
	And I typed the domain name gss
	And I choose the domain .com.tw
	When I press the button 查詢
	Then The result should be gss.com.tw 已被註冊

@purchasingConditions
Scenario Outline: 搜尋網域, 填寫資料無誤後取消購買
	Given I navigated to /
	And I typed the domain name chrisFsWang
	And I choose the domain .cc
	And I press the button 查詢
	And I press the button 確定送出
	And I press the button 下一步
	And Enter form details
		|IdentityNumber|ChineseName   |EnglishFirstName  |EnglishLastName |PostalCode |ChineseAddress |EnglishAddress |City      |ContactNumber  |Cellphone   |Email   |BackupEmail   |DomainPassword |ConfirmDomainPassword |
		|<Id>          |<CName>       |<EFirstName>      |<ELastName>     |<PCode>    |<CAddress>     |<EAddress>     |<City>    |<ContactNumber>|<Cellphone> |<Email> |<BackupEmail> |<DomainPw>     |<ConfirmDomainPw>     |
	And I choose the checkBox 電子發票由上方註冊資料帶入
	And I choose the checkBox 網域名稱申購約定條款
	And I choose the checkBox 中華電信個資蒐集告知條款
	And I choose the checkBox 同意推介個人化商品服務
	And I press the button 確定
	When I press the button 取消購買
	Then The function title should be 選擇域名
	Examples:
		|Id         |CName   |EFirstName  |ELastName |PCode      |CAddress                         |EAddress                                                                                         |City      |ContactNumber |Cellphone  |Email                 |BackupEmail           |DomainPw  |ConfirmDomainPw       |
		|B201251014 |王曉明   |chris       |wang      |10653      |台北市大安區忠孝東路三段217巷10號     |No. 10, Aly. 3, Ln. 217, Sec. 3, Zhongxiao E. Rd., Da’an Dist., Taipei City 106, Taiwan (R.O.C.) |Taipei    |979123456     |0979123456 |s0979123456@gmail.com |s0979654321@gmail.com |FFFFfff@8 |FFFFfff@8  |
		|B201251014 |王大明   |chris       |wang      |10653      |台北市大安區忠孝東路三段217巷10號     |No. 10, Aly. 3, Ln. 217, Sec. 3, Zhongxiao E. Rd., Da’an Dist., Taipei City 106, Taiwan (R.O.C.) |Taipei    |979123456     |0979123456 |s0979123456@gmail.com |s0979654321@gmail.com |FFFFfff@8 |FFFFfff@8  |
		|B201251014 |王中明   |chris       |wang      |10653      |台北市大安區忠孝東路三段217巷10號     |No. 10, Aly. 3, Ln. 217, Sec. 3, Zhongxiao E. Rd., Da’an Dist., Taipei City 106, Taiwan (R.O.C.) |Taipei    |979123456     |0979123456 |s0979123456@gmail.com |s0979654321@gmail.com |FFFFfff@8 |FFFFfff@8  |
		

@purchasingConditions
Scenario Outline: 搜尋網域, 填寫資料錯誤後顯示訊息
	Given I navigated to /
	And I typed the domain name chrisFsWang
	And I choose the domain .cc
	And I press the button 查詢
	And I press the button 確定送出
	And I press the button 下一步
	And Enter form details
		|IdentityNumber|ChineseName   |EnglishFirstName  |EnglishLastName |PostalCode |ChineseAddress |EnglishAddress |City      |ContactNumber  |Cellphone   |Email   |BackupEmail   |DomainPassword |ConfirmDomainPassword |
		|<Id>          |<CName>       |<EFirstName>      |<ELastName>     |<PCode>    |<CAddress>     |<EAddress>     |<City>    |<ContactNumber>|<Cellphone> |<Email> |<BackupEmail> |<DomainPw>     |<ConfirmDomainPw>     |
	And I choose the checkBox 電子發票由上方註冊資料帶入
	And I choose the checkBox 網域名稱申購約定條款
	And I choose the checkBox 中華電信個資蒐集告知條款
	And I press the button 確定
	Then The alert message of browser should be <errorMessage>
	Examples:
		|errorMessage                                   |Id         | CName |EFirstName  |ELastName  |PCode |CAddress                     |EAddress                                                                                         |City   |ContactNumber |Cellphone  |Email                 |BackupEmail           |DomainPw  |ConfirmDomainPw |
		|請選擇是否同意中華電信股份有限公司推介多元化商品服務！  |B201251014 |王曉明  |chris       |wang       |10653 |台北市大安區忠孝東路三段217巷10號 |No. 10, Aly. 3, Ln. 217, Sec. 3, Zhongxiao E. Rd., Da’an Dist., Taipei City 106, Taiwan (R.O.C.) |Taipei |979123456     |0979123456 |s0979123456@gmail.com |s0979654321@gmail.com |FFFFfff@8 |FFFFfff@8       |