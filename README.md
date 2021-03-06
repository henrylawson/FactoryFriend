# Introduction
FactoryFriend is a simple DSL for defining and creating factories in 
.Net. FactoryFriend makes creating factories for a large number of
objects easy and maintainable.

# Why use FactoryFriend?
FactoryFriend's true power is seen when utilised alongside a
testing framework. FactoryFriend can be used to clean up and simplify
the repetetive creation of domain model instances. Often the same domain
models are required but with varying states. These states may be "valid",
"invalid", "complete" or "incomplete". FactoryFriend allows you to
define these states in a single location and then provides support for the
extension of these definitions, improving maintainability and reducing the
complexity of your code.

# Getting Started
## Download the Assembly
You can download the latest version `dll` from the [downloads page](https://github.com/henrylawson/FactoryFriend/downloads).

## Reference the Assembly
In Visual Studio, in the `Solution Explorer` window. Expand your .Net 
project folder, right click the `References` folder. Select `Add Reference`, 
the `Browse` tab and then simply navigate to and then select the
`FactoryFriendCore.dll`.

## Before we dive into the code
The preceeding examples assume the existence of the below domain model class:

```c#
public class Person
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
}
```

## Define your Factory
Before you can use FactoryFriend to build some objects, you have to 
define some first! A factory can be defined using two methods, Inline
Notation and Templates.

The below exmaples define a factory with the alias `WithValidProperties`. The 
alias is used to `Build` `Person` instances and `Extend` the factory later.
### Using Inline Notation

```c#
FactoryFriend.Define<Person>("WithValidProperties").As(x => 
	{
		x.Id = 22;
		x.FirstName = "Joe";
		x.LastName = "Bloggs";
		return x;
	});
```
### Using Templates
A template is simply a class that extends the `IFactoryFriendTemplate` 
interface. FactoryFriend searches the assemblies and uses reflection
to find and load your templates at run time. 

```c#
public class PersonTemplate : IFactoryFriendTemplate
{
	public Person WithValidProperties(Person x)
	{
		x.Id = 22;
		x.FirstName = "Joe";
		x.LastName = "Bloggs";
		return x;
	}
}
```
	
## Why the two methods?
FactoryFriend has two techniques for object definition purely for flexibility. 
Inline Notation is convenient when you simply need to define a simple object
in the `SetUp` method of your tests. The Template method is more powerful
when you need to define lots of different factories. Defining and recording
them all in a single maintainable place.

## Extending your defined Factory
Often when dealing with domain model entities you will have one base object 
that you use to derive various other objects. The derived objects will often 
have one or two properties different to the base. To avoid redefining these
properties again, FactoryFriend allows you to extend these previously 
defined factories.

The below examples extend our previously defined factory `ValidProperities` 
changing the `Id` to be `0`. These factories will still return an object with 
the previously defined `FirstName = "Joe"` and `LastName = "Bloggs"`.

### Using Inline Notation

```c#
FactoryFriend.Extend<Person>("WithValidProperties", "WithNoId").As(x => 
	{
		x.Id = 0;
		return x;
	});
```

### Using Templates

```c#
public class PersonTemplate : IFactoryFriendTemplate
{
	// ... Previously defined  "ValidProperties" propertes method
	
	[Extends("WithValidProperties")]
	public Person WithNoId(Person x)
	{
		x.Id = 0;
		return x;
	}
}
```

## Using your defined Factories
Now that you have defined and extended your factories, its now time to get an object
out of them. A fresh object is returned, with the defined properties set by calling:

```c#
var personWithValidProperties = FactoryFriend.Build<Person>("WithValidProperties");
var personWithNoId = FactoryFriend.Build<Person>("WithNoId");
```
	
Note that for the above objects, all statements below are true.

```c#
// For personWithValidProperties, made using "WithValidProperties" factory
Assert.That(personWithValidProperties.FirstName, Is.EqualTo("Joe"));
Assert.That(personWithValidProperties.LastName, Is.EqualTo("Bloggs"));
Assert.That(personWithValidProperties.Id, Is.EqualTo(22));

// For personWithNoId, made using "WithValidProperties" factory
Assert.That(personWithValidProperties.FirstName, Is.EqualTo("Joe"));
Assert.That(personWithValidProperties.LastName, Is.EqualTo("Bloggs"));
Assert.That(personWithValidProperties.Id, Is.EqualTo(0));
```

## Clearing out all your defined Factories
To clear out your Inline Notation defined and extended factories, simply call:

```c#
FactoryFriend.Clear();
```

Your Template defined factories stay defined for the entire lifetime of
FactoryFriend. Clearing out Inline Notation defined factories may be useful
to clear out definitions/extensions at the end of a test in a `TearDown` 
method.

## The next level
The example provided here is quite basic. However the true usefulness of 
FactoryFriend shines through when objects reference other objects and your
domain model relationships are more complicated with large ammounts of 
properties.

The below example assumes the existence of domain classess for `Company`, 
`Address`, `CreditCard` and `Person`.

```c#
public class PersonTemplate : IFactoryFriendTemplate
{
	public Person WithValidProperties(Person x)
	{
		x.Id = 22;
		x.FirstName = "Joe";
		x.LastName = "Bloggs";
		x.Company = FactoryFriend.Build<Company>("WithValidProperties");
		x.MailingAddress = FactoryFriend.Build<Address>("ForAppartmentInLondon");
		x.MailingAddress = FactoryFriend.Build<Address>("ForHomeInManchester");
		x.CreditCard = FactoryFriend.Build<CreditCard>("WithValidProperties");
		return x;
	}
	
	[Extends("WithValidProperties")]
	public Person WithInvalidCreditCard(Person x)
	{
		x.CreditCard = FactoryFriend.Build<CreditCard>("ThatIsExpired");
		return x;
	}
	
	[Extends("WithValidProperties")]
	public Person ThatIsUnemployed(Person x)
	{
		x.Company = null;
		return x;
	}
	
	[Extends("ThatIsUnemployed", "WithInvalidCreditCard")]
	public Person ThatIsUnemployedWithExpiredCreditCardAndNoMailingAddress(Person x)
	{
		x.MailingAddress = null;
		return x;
	}
}
```

The last one is a little bit silly but I'm sure you can see the potential FactoryFriend 
has to be both extremelly useful and a little confusing. Like most tools, use sparingly
and only where appropriate to get the most value.

## Where can I learn more?
For more usage examples see the `FactoryFriendCore.Test` project in the 
source code. The source code documentation may also be useful.

# Contributing
1. Fork the official repository.
2. Make your changes in a topic branch (don't forget your tests!).
3. Send a pull request.

# Credits
FactoryFriend was developed by Henry Lawson and is released under the [MIT Open Source License](http://www.opensource.org/licenses/MIT).

