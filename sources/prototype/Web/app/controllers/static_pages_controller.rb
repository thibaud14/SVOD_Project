class StaticPagesController < ApplicationController
  def home
    if signed_in?
      redirect_to :action => 'content'
    end
  end

  def content
    if !signed_in?
      redirect_to :action => 'home'
    end
  end

  def help
  end

  def about

  end
end
