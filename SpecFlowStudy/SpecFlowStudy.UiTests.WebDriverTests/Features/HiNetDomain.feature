Feature: HiNetDomain
	In order to 測試網站能否使用
	As a 網站使用者
	I want to 前往網站並確認是否正常

@basePage
Scenario: 首頁是Domain HiNet
	Given I navigated to https://domain.hinet.net
	Then The title should be HiNet 域名註冊




