﻿Feature: HiNetDomain-IE
	In order to 購買網域
	As a 潛在消費者
	I want to 知道我想要購買的網域有沒有人使用並購買

Background:
	Given 我選擇IE瀏覽器

@basePage
Scenario: 首頁是Domain HiNet
	Given I navigated to /
	Then The title should be HiNet 域名註冊