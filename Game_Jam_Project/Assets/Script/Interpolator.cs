using System;

public class Interpolator
{
    public enum State { MIN, MAX, SHRINKING, GROWING}
    public enum Type { LINEAR, SIN, COS, QUADRATIC, SMOOTH, SMOOTHER}

    private State m_interpolationState = State.MIN;
    private Type m_interpolationType;

    private readonly float m_epsilon = 0.05f;
    private float m_currentTime = 0.0f;
    private float m_interpolationTime;

    public float Value { get; private set; } = 0.0f;
    public float Inverse { get { return 1 - Value; } }

    public bool IsMaxPrecise { get { return this.m_interpolationState == State.MAX; } }
    public bool IsMax { get { return Value > 1f - m_epsilon; } }

    public bool IsMinPrecise { get { return this.m_interpolationState == State.MIN; } }
    public bool IsMin { get { return Value < m_epsilon; } }

    public Interpolator(float interpolationTime, Type interpolationType = Type.LINEAR)
    {
        m_interpolationTime = interpolationTime;
        m_interpolationType = interpolationType;
    }

    public void Update(float dt)
    {
        if (this.m_interpolationState == State.MIN || this.m_interpolationState == State.MAX)
            return;

        float modifiedDt = this.m_interpolationState == State.GROWING ? dt : -dt;

        m_currentTime += modifiedDt;

        if (m_currentTime >= m_interpolationTime)
            ForceMax();
        else if (m_currentTime <= 0.0f)
            ForceMin();

        Value = m_currentTime / m_interpolationTime;
        switch (m_interpolationType)
        {
            case Type.SIN:
                Value = (float)Math.Sin(Value * Math.PI * 0.5f);
                break;
            case Type.COS:
                Value =  1f - (float)Math.Cos(Value * Math.PI * 0.5f);
                break;
            case Type.QUADRATIC:
                Value *= Value;
                break;
            case Type.SMOOTH:
                Value = Value * Value * (3f - 2f * Value);
                break;
            case Type.SMOOTHER:
                Value = (float)Math.Pow(Value, 3f) * (Value * (6f * Value - 15f) + 10f);
                break;
            default:
                break;
        }
    }

    //Interpolation changers
    public void ToMax() {
        this.m_interpolationState = this.m_interpolationState != State.MAX ? State.GROWING : State.MAX;
    }
    public void ToMin() {
        this.m_interpolationState = this.m_interpolationState != State.MIN ? State.SHRINKING : State.MIN;
    }
    public void ForceMax() {
        this.m_currentTime = this.m_interpolationTime;
        Value = 1f;
        this.m_interpolationState = State.MAX;
    }
    public void ForceMin() {
        this.m_currentTime = 0.0f;
        Value = 0f;
        this.m_interpolationState = State.MIN;
    }
}
