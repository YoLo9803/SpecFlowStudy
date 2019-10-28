Feature: wikiFeature
	In order to 在wiki找到想要的資料
	As a 想查詢資料的人
	I want to 得到我想查詢的資料

@mytag
Scenario: Basepage is the main page of wiki
	Given I navigated to /Main_Page
	Then browser title is Wikipedia, the free encyclopedia
