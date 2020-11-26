namespace FStest.SomeDomainTests

open Microsoft.VisualStudio.TestTools.UnitTesting
open DomainEntity

[<TestClass>]
type DomainEntityTests () =

    [<TestMethod>]
    member _this.SayHello_PassViktorReturnsExpected () =
        let extected = "Hello, Viktor"

        let result = sayHello "Viktor"

        Assert.AreEqual(extected, result);
        
    [<TestMethod>]
    member _this.``pass 3 returns list of 3 elements`` () =      

        let result = getList 3

        Assert.AreEqual(3, (List.length result));
