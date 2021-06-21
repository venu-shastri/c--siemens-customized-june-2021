class A{
public void Invoke(I obj){}
}

interface I{	void Test();}

class B:I{ public void Test(){}}

class C:I{public void Test(){}}

class  Composite :I{
	List<I> _list=new List<I>();
	publi void Add(I item){ _list.Add(item);
	publi void Remove(I item){ _list.Remove(item);
	public void Test(){
	foreach(I item in _list){ item.Test();}
      }
}

Main(){
A obj=new A();
obj.Invoke(new B());
obj.Invoke(new C());
Composite _composite=new  Composite();
_composite.Add(new B());
_composite.Add(new C());
obj.Invoke(_composite);
}
