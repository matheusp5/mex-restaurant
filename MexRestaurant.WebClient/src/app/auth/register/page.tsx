"use client";
import { useForm } from "react-hook-form";
import { IRegisterRequest } from "@/requests/AuthRequest";
import { redirect } from "next/navigation";
import { handleRegisterContext } from "@/services/AuthService";

export default function Register() {
  const { register, handleSubmit } = useForm();

  const handleRegisterForm = ({ email, password, username }: any) => {
    handleRegisterContext(email, password, username).then(
      (result: IRegisterRequest) => {
        if (result.isSucceeded) {
          return redirect("/")
        }
      }
    );
  };

  return (
    <>
      <div className="min-h-screen bg-gray-100 py-6 flex flex-col justify-center sm:py-12">
        <div className="relative py-3 sm:max-w-xl sm:mx-auto">
          <div className="relative px-4 py-10 bg-white shadow-lg sm:rounded-3xl sm:p-20">
            <div className="max-w-md mx-auto">
              <div>
                <h1 className="text-2xl font-semibold">
                  enter your credentials to continue.
                </h1>
              </div>
              <div className="divide-y divide-gray-200">
                <div className="py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7">
                  <form onSubmit={handleSubmit(handleRegisterForm)}>
                    <div className="relative">
                      <input
                        autoComplete="off"
                        id="email"
                        type="text"
                        className="mb-4 peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:borer-rose-600"
                        placeholder="e-mail"
                        {...register("email")}
                      />
                      <label
                        htmlFor="email"
                        className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm"
                      >
                        e-mail
                      </label>
                    </div>
                    <div className="relative">
                      <input
                        autoComplete="off"
                        id="username"
                        type="text"
                        className="mb-4  peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:borer-rose-600"
                        placeholder="username"
                        {...register("username")}
                      />
                      <label
                        htmlFor="username"
                        className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm"
                      >
                        username
                      </label>
                    </div>
                    <div className="relative">
                      <input
                        autoComplete="off"
                        id="password"
                        type="password"
                        className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:borer-rose-600"
                        placeholder="password"
                        {...register("password")}
                      />
                      <label
                        htmlFor="password"
                        className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm"
                      >
                        password
                      </label>
                    </div>
                    <div className="relative">
                      <button
                        type="submit"
                        className="bg-purple-500 text-white rounded-md px-8 mt-4 py-1"
                      >
                        continue
                      </button>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
}
