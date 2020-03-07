class Electronics{
public static int price;
public static class Television{
public static void cost()                // Through Static method
{
System.out.println("call through static method Price is "+5000);
}
public  void cost1()                // Through Non-Static method
{
System.out.println("call through non-static method Price is "+10000);
}  }  }
public class Main{
public static void main(String args[]){
Electronics.Television.cost();                               // call  static method
Electronics.Television tv=new Electronics.Television();      // call non-static method
tv.cost1();
}   }
