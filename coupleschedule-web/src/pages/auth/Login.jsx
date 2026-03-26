import { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { useAuth } from '../../contexts/AuthContext';

export function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const { login } = useAuth();
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await login(email, password);
            navigate('/dashboard');
        } catch (err) {
            alert("Credenciais inválidas! Verifique se o Backend está rodando.");
        }
    };

    return (
        <div className="min-h-screen flex items-center justify-center bg-slate-50 px-4">    
            <div className="max-w-md w-full bg-white rounded-3xl shadow-xl border border-slate-100 p-10 space-y-8">
                
                <div className="text-center">
                    <h1 className="text-4xl font-black bg-gradient-to-r from-indigo-600 to-violet-600 bg-clip-text text-transparent">
                        CoupleSchedule
                    </h1>
                    <p className="mt-3 text-slate-500 font-medium text-sm">
                        Sincronize sua rotina com quem você ama.
                    </p>
                </div>

                <form onSubmit={handleSubmit} className="space-y-6">
                    <div className="space-y-4">
                        <div className="group">
                            <label className="block text-xs font-bold text-slate-400 uppercase tracking-widest mb-2 ml-1">
                                Email
                            </label>
                            <input 
                                type="email" 
                                required
                                value={email} 
                                onChange={(e) => setEmail(e.target.value)}
                                className="w-full px-5 py-4 rounded-2xl bg-slate-50 border border-slate-200 focus:border-indigo-500 focus:ring-4 focus:ring-indigo-50/50 outline-none transition-all placeholder:text-slate-400"
                                placeholder="exemplo@email.com"
                            />
                        </div>

                        <div className="group">
                            <label className="block text-xs font-bold text-slate-400 uppercase tracking-widest mb-2 ml-1">
                                Senha
                            </label>
                            <input 
                                type="password" 
                                required
                                value={password} 
                                onChange={(e) => setPassword(e.target.value)}
                                className="w-full px-5 py-4 rounded-2xl bg-slate-50 border border-slate-200 focus:border-indigo-500 focus:ring-4 focus:ring-indigo-50/50 outline-none transition-all placeholder:text-slate-400"
                                placeholder="••••••••"
                            />
                        </div>
                    </div>

                    <button 
                        type="submit"
                        className="w-full bg-indigo-600 hover:bg-indigo-700 text-white font-bold py-4 rounded-2xl shadow-lg shadow-indigo-200 transition-all active:scale-[0.98] flex items-center justify-center gap-2 group"
                    >
                        <span>Entrar no App</span>
                        <svg className="w-5 h-5 group-hover:translate-x-1 transition-transform" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M13 7l5 5m0 0l-5 5m5-5H6" />
                        </svg>
                    </button>
                </form>

                <div className="text-center pt-4">
                    <p className="text-xs text-slate-400">
                        Não tem conta? <Link to="/register" className="text-indigo-600 font-bold hover:underline">Cadastre-se aqui.</Link>
                    </p>
                </div>
            </div>
        </div>
    );
}