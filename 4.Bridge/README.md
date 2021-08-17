# Bridge Pattern (Behavioural)

- OFFICIAL: Its purpose is to decouple an abstraction from its implementation so that the two can vary independently.(confusion. This is not about Intefaces and its concrete implementations)

* Its purpose is to split a class hierarcy through composition to reduce coupling.

Eg: Online Movie theater

                    MovieLicense
                    * Movie
                    * purchaseTime
                    * GetPrice()
                    * GetExpirationDate()
                            |
              --------------------------------
              |                               |
          TwoDaysLicense              LifeLongLicense

##### naive approch (split the hierarchy) without Bridge

                                  MovieLicense
                                        ^
                                        |
                            -------------------------------
                            ^                              ^
                            |                               |
                      TwoDaysLicense                    LifeLongLicense
                            |                               |
                  ---------------------               -------------------
                  |                     |              |                  |
        Military2DaysLicenseDcnt  Senior2DayLisce  MilitaryLifeLong   SineorLifeLong

- issue here is after 2day,LifeLong Licence, if new requirement like Military,Senior Discount comes we have onemore hierarcy

* this approch leads to exponential growth of class hierarchy
* 2classes rised to 6 for two types of discounts.it will raised to 12 classes if 5 types of discounts.>>issue
* 2 -> 6 -> 12 -> 18 exponential growth of classes
* Duplication of application business logic/ domain knowledge

#### With Bridge

- according to this, you have to split class hierarchy in two.

* instead of overriding , create separate class hiearchy called discount.

              MovieLicense ---------Bridge------->Discount
                  ^                                   ^
                  |                                   |
          ------------------              --------------------------
          |                 |             |           |              |

  TwoDayLicense LifeLongLicense MilitaryDsct | SeniorDsct
  NoDiscount

      * No DRY Principle Violation >all business rules with regards to how to calculate the discounts are located in one place which is the respective classes of discount hierarchy.
      * simplified Code
      * prfer composition over inheritence

| requirement               | naive      | bridge     |
| ------------------------- | ---------- | ---------- |
| 2 licences \* 3 discounts | 6 classes  |
| 5 licences \* 5 discounts | 25 classes | 10 classes |

- so, BRIDGE pattern replaces complexity multiplication with complexity addition

* prevents exponential growth of complexity(complexity explosion)
* complexity emerges from coupling(connection between code elements).larger the number ,higher the complexity
* eg: 2 licence types, 3 discount types.In naive implementation each licence is connected to every variation of discount, which results in multiplication of number of connections.Whereas in BRIDGE we grouped all variation of licence, discount, such that they are only connected to their base class and one connection between base classes.Here 1.Isolation of two aspects, so achieved high cohesion among elements of each aspect and loosing coupling between aspects themselves.
* official definition is confusing because Discount is not the implementaion of movieLicense abstracton
* simple example of Bridge pattern : splitting status enum to paymentStatus, deliverystatus enums
* prefer composition over inheritence
* Composition is more flexible than inheritance because of easier to change, inheritance is rigid, easy to understand
