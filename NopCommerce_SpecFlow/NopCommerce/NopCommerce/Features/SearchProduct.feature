@SearchProduct
Feature: Search product
    As a user, I would like to search product

    @VerifySearchProductLayout
    Scenario Outline: Category and Manufacturer dropdown list are showed - click Advanced search
        Given I am in Search page
        When I click "<numberOfTimes>" to choose Advanced search
        Then the advanced search fields are "<showedOrHidden>"
        Examples:
            | numberOfTimes | showedOrHidden |
            | 1             | showed         |
            | 3             | showed         |
            | 10            | hidden         |
            | 6             | hidden         |

    @SearchProductUnsuccessfully
    Scenario Outline: Search unsuccessfully - no advanced search
        Given I am in Search page
        When I input "<keyword>" to Search field
        And I click Search button
        Then the Search page displays "<message>"
        Examples:
            | Scenario                   | keyword | message                                            |
            | Empty keyword              |         | Search term minimum length is 3 characters         |
            | Keyword length less than 3 | ha      | Search term minimum length is 3 characters         |
            | Keyword not found          | hairlee | No products were found that matched your criteria. |

    @SearchProductSuccessfully
    Scenario Outline: Search successfully - no advanced search, keyword is Product name or Product category
        Given I am in Search page
        When I input "<keyword>" to Search field
        And I click Search button
        Then the Search page displays products related to "<keyword>"
        Examples:
            | keyword |
            | book    |
            | phone   |
            | Nokia   |

    @SearchProductSuccessfully
    Scenario Outline: Search product successfully - advanced search
        Given I am in Search page
        When I input "<keyword>" to Search field
        And I click to choose Advanced search
        And I click to choose category dropdown value "<category>", click "<autoSubCategory>" auto search sub categories checkbox, choose manufacturer dropdown value "<manufacturer>", click "<onlyDescription>" search in product descriptions checkbox
        And I click Search button
        Then the Search page displays product which is related to keyword "<keyword>" and advanced options
        Examples:
            | Scenario                            | keyword                                  | category               | autoSubCategory | manufacturer | onlyDescription |
            | With category                       | book                                     | Computers >> Notebooks |                 |              |                 |
            | With auto search sub categories     | book                                     |                        | select          |              |                 |
            | With manufacturer                   | book                                     |                        |                 | Apple        |                 |
            | With search in product descriptions | Set in England in the early 19th century |                        |                 |              | select          |
            | Full advanced options               | interchangeable lenses                   | Electronics            | select          | Apple        | select          |
            | Any advanced options 1              | interchangeable lenses                   | Electronics            | select          |              | select          |
            | Any advanced options 2              | book                                     | Computers              | select          |              |                 |

    @VerifySearchResultUnchanged
    Scenario Outline: Verify that search product result is unchanged when user refreshes page - no advanced, search by name or category
        Given I am in Search page
        When I input "<keyword>" to Search field
        And I click Search button
        And the Search page displays products related to "<keyword>"
        And I refresh the page
        Then the search result is not changed
        Examples:
            | keyword |
            | book    |
            | phone   |

    @VerifySearchResultUnchanged
    Scenario Outline: Verify that search product result is unchanged when user refreshes page - advanced search
        Given I am in Search page
        When I input "<keyword>" to Search field
        And I click to choose Advanced search
        And I click to choose category dropdown value "<category>", click "<autoSubCategory>" auto search sub categories checkbox, choose manufacturer dropdown value "<manufacturer>", click "<onlyDescription>" search in product descriptions checkbox
        And I click Search button
        And the Search page displays product which is related to keyword "<keyword>" and advanced options
        And I refresh the page
        Then the search result is not changed
        Examples:
            | Scenario                            | keyword                                  | category               | autoSubCategory | manufacturer | onlyDescription |
            | Any advanced options 1              | interchangeable lenses                   | Electronics            | select          |              | select          |
            | Any advanced options 2              | book                                     | Computers              | select          |              |                 |