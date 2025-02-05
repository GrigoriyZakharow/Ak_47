public class Node {

  public Node next;
  public Node previous;
  public string value;

  public Node(string value) {
    this.value = value;
  }
}

public class TwoWayQueue {

  public Node tail;
  public Node head;
  public int count;
  public string First => head.value;
  public string Last => tail.value;

  public TwoWayQueue() { }

  public void AddFirst(string obj) {

    Node containerNode = new Node(obj);
    Node temp = head;

    containerNode.next = temp;
    head = containerNode;

    if (count == 0) tail = head;
    else temp.previous = containerNode;

    count++;
  }

  public void AddLast(string obj) {

    Node containerNode = new Node(obj);

    if (head is null) {
      head = containerNode;
    }
    else {
      tail.next = containerNode;
      containerNode.previous = tail;
    }

    tail = containerNode;
    count++;
  }

  public string RemoveFirst() {

    string output = head.value;

    if (count == 1) {
      head = tail = null;
    }
    else {
      head = head.next;
      head.previous = null;
    }

    count--;
    return output;
  }

  public string RemoveLast() {

    string output = tail.value;

    if (count == 1) {
      head = tail = null;
    }
    else {
      tail = tail.previous;
      tail.next = null;
    }

    count--;
    return output;
  }

  public void Clear() {
    head = null;
    tail = null;
    count = 0;
  }
}