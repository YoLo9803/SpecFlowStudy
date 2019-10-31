Feature: HiNetDomain
	In order to 購買網域
	As a 潛在消費者
	I want to 知道我想要購買的網域有沒有人使用

@basePage
Scenario: Basepage is the main page of Domain-HiNet
	Given I navigated to /
	Then browser title is HiNet 域名註冊

@checkDomain
Scenario: Domain is being used
	Given I navigated to /
	And I typed the domain name google
	And I choose the domain .com
	When I press the button 查詢
	Then The result should be google.com 已被註冊