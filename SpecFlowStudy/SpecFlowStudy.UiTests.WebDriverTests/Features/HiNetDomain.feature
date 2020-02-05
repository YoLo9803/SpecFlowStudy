Feature: HiNetDomain
	In order to 測試網站能否使用
	As a 網站使用者
	I want to 前往網站並確認是否正常

@basePage
Scenario: 首頁是Domain HiNet
	Given I navigated to https://domain.hinet.net
	Then The title should be HiNet 域名註冊

@assertText
Scenario: 進入首頁後應該進到選擇域名頁面
	Given I navigated to https://domain.hinet.net
	Then The tag should be 選擇域名


